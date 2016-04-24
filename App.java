package org.sample.jms;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.util.Properties;

public class App {
  public static void main(String[] args) {
	
	Properties prop = new Properties();
	OutputStream output = null;

	try {

		output = new FileOutputStream("config.properties");
/*
 *     public static final String QPID_ICF = "org.wso2.andes.jndi.PropertiesFileInitialContextFactory";
    private static final String CF_NAME_PREFIX = "connectionfactory.";
    private static final String CF_NAME = "qpidConnectionfactory";
    String userName = "admin";
    String password = "admin";
    private static String CARBON_CLIENT_ID = "carbon";
    private static String CARBON_VIRTUAL_HOST_NAME = "carbon";
    private static String CARBON_DEFAULT_HOSTNAME = "localhost";
    private static String CARBON_DEFAULT_PORT = "5672";
    String topicName ="MYTopic";
 
 * 
 * 
 * */
		// set the properties value
		prop.setProperty("QPID_ICF", "org.wso2.andes.jndi.PropertiesFileInitialContextFactory");
		prop.setProperty("CF_NAME_PREFIX", "connectionfactory.");
		prop.setProperty("CF_NAME", "qpidConnectionfactory");
		prop.setProperty("userName", "admin");
		prop.setProperty("CARBON_CLIENT_ID", "carbon");
		prop.setProperty("CARBON_VIRTUAL_HOST_NAME", "carbon");
		prop.setProperty("CARBON_DEFAULT_HOSTNAME", "localhost");
		prop.setProperty("CARBON_DEFAULT_PORT", "5672");
		prop.setProperty("topicName", "MYTopic");
		// save properties to project root folder
		prop.store(output, null);

	} catch (IOException io) {
		io.printStackTrace();
	} finally {
		if (output != null) {
			try {
				output.close();
			} catch (IOException e) {
				e.printStackTrace();
			}
		}

	}
  }
}
