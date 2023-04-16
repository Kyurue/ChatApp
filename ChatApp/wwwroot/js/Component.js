import { template } from "/js/modules/template.js";
import { Message } from "/js/components/message.js";
import { SenderMessage } from "/js/components/senderMessage.js";

//attach templates
template.attachTemplates();
const chat = document.getElementById("chat");
myArray.forEach((element) => {
    chat.appendChild(new Message(element.message, element.time, element.userId));
});