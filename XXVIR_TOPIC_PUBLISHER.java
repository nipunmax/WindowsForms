package org.sample.jms;

import javax.jms.JMSException;
import javax.jms.QueueSession;
import javax.jms.TextMessage;
import javax.jms.Topic;
import javax.jms.TopicConnection;
import javax.jms.TopicConnectionFactory;
import javax.jms.TopicPublisher;
import javax.jms.TopicSession;
import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import java.util.Properties;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

public class XXVIR_TOPIC_PUBLISHER {

	private String QPID_ICF = null;// "org.wso2.andes.jndi.PropertiesFileInitialContextFactory";
	private String CF_NAME_PREFIX = null;// "connectionfactory.";
	private String CF_NAME = null;// "qpidConnectionfactory";
	private String userName = null;// "admin";
	private String password = null;// "admin";
	private String CARBON_CLIENT_ID = null;// "carbon";
	private String CARBON_VIRTUAL_HOST_NAME = null;// "carbon";
	private String CARBON_DEFAULT_HOSTNAME = null;// "localhost";
	private String CARBON_DEFAULT_PORT = null;// "5672";
	private String topicName = null;// "MYTopic";
	private TopicConnectionFactory connFactory = null;
	private TopicConnection topicConnection = null;
	private TopicSession topicSession = null;
	private Topic topic = null;
	private TextMessage textMessage = null;
	private TopicPublisher topicPublisher = null;
	private InputStream input = null;

	public void publishMessage(String message) {

		Properties prop = new Properties();

		try {

			input = new FileInputStream("config.properties");

			// load a properties file
			prop.load(input);

			QPID_ICF = prop.getProperty("QPID_ICF");
			CF_NAME_PREFIX = prop.getProperty("CF_NAME_PREFIX");
			CF_NAME = prop.getProperty("CF_NAME");
			userName = prop.getProperty("userName");
			password = prop.getProperty("password");
			CARBON_CLIENT_ID = prop.getProperty("CARBON_CLIENT_ID");
			CARBON_VIRTUAL_HOST_NAME = prop.getProperty("CARBON_VIRTUAL_HOST_NAME");
			CARBON_DEFAULT_HOSTNAME = prop.getProperty("CARBON_DEFAULT_HOSTNAME");
			CARBON_DEFAULT_PORT = prop.getProperty("CARBON_DEFAULT_PORT");
			topicName = prop.getProperty("topicName");
			QPID_ICF = prop.getProperty("QPID_ICF");

			Properties properties = new Properties();
			properties.put(Context.INITIAL_CONTEXT_FACTORY, QPID_ICF);
			properties.put(CF_NAME_PREFIX + CF_NAME, getTCPConnectionURL(userName, password));
			System.out.println("getTCPConnectionURL(userName,password) = " + getTCPConnectionURL(userName, password));
			InitialContext ctx = new InitialContext(properties);
			// Lookup connection factory
			connFactory = (TopicConnectionFactory) ctx.lookup(CF_NAME);
			topicConnection = connFactory.createTopicConnection();
			topicConnection.start();
			topicSession = topicConnection.createTopicSession(false, QueueSession.AUTO_ACKNOWLEDGE);
			// Send message
			topic = topicSession.createTopic(topicName);
			// create the message to send
			textMessage = topicSession.createTextMessage(message);
			topicPublisher = topicSession.createPublisher(topic);
			topicPublisher.publish(textMessage);
		} catch (NamingException e) {
			e.printStackTrace();
		} catch (JMSException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		}

		finally {
			if (input != null) {
				try {
					input.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
			try {
				topicPublisher.close();
				topicSession.close();
				topicConnection.stop();
				topicConnection.close();
			} catch (JMSException e) {
				e.printStackTrace();
			}

		}
	}

	private String getTCPConnectionURL(String username, String password) {
		// amqp://{username}:{password}@carbon/carbon?brokerlist='tcp://{hostname}:{port}'
		return new StringBuffer().append("amqp://").append(username).append(":").append(password).append("@")
				.append(CARBON_CLIENT_ID).append("/").append(CARBON_VIRTUAL_HOST_NAME).append("?brokerlist='tcp://")
				.append(CARBON_DEFAULT_HOSTNAME).append(":").append(CARBON_DEFAULT_PORT).append("'").toString();
	}
}
