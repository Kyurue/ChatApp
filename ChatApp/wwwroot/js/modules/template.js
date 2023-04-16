//Chat message (still need to add user)
const chatMessage = {
    id: 'chat-message-tpl',
    template: `
    <div class="chatMessage">
        <p class="username" data-bind="user"></p>
        <p class="message" data-bind="message"></p>
        <p class="time" data-bind="time"></p>
    </div>
    `
}

//Chat message for sender (still need to add text "You" (since "you're" the sender))
const senderMessage = {
    id: 'sender-message-tpl',
    template: `
    <div class="chatMessage userMessage">
        <p class="message" data-bind="message"></p>
        <p class="time" data-bind="time"></p>
    </div>
    `
}

//template class
class Template
{
    attachTemplates(){
        this.attachTemplate(chatMessage);
        this.attachTemplate(senderMessage);
    }

    //attach template individually
    attachTemplate(tplObject){
        const templateNode = document.createElement('template');
        templateNode.id = tplObject.id;
        templateNode.innerHTML = tplObject.template;
        const body = document.querySelector('body');
        body.appendChild(templateNode);
    }

}

//initialize and export template
const template = new Template();
export {template};
