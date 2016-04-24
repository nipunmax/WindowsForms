

package org.sample.jms;

import javax.jms.JMSException;
import javax.naming.NamingException;
import javax.jms.TopicSubscriber;

public class Main {

	public static void main(String[] args) throws JMSException , NamingException {
		
        XXVIR_TOPIC_SUBSCRIBER topicSubscriber = new XXVIR_TOPIC_SUBSCRIBER();
        TopicSubscriber subscriber = topicSubscriber.subscribe();
        XXVIR_TOPIC_PUBLISHER topicPublisher = new XXVIR_TOPIC_PUBLISHER();
        topicPublisher.publishMessage("Okay so how about this");
        topicSubscriber.receive(subscriber);

    }

}









