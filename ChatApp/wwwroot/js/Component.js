import { template } from "/js/modules/template.js";
import { Message } from "/js/components/message.js";
import { SenderMessage } from "/js/components/senderMessage.js";

//attach templates
template.attachTemplates();
var message = Message;

//create components
const messageComponent = new Message("eerste", "17:09", "user1");
const senderComponent = new SenderMessage("tweede", "17:09")

//append components
const chat = document.getElementById("chat");
chat.prepend(senderComponent);
chat.prepend(messageComponent);