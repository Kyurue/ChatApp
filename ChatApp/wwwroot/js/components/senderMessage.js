class SenderMessage extends HTMLElement {

    //start shadowroot <- is this necessary?
    shadowRoot;
    templateId = 'sender-message-tpl';
    elementId = 'sender-message';

     //initialize component (constructor)
    constructor(message, time) {
        super(); // always call super() first in the ctor.
        this.shadowRoot = this.attachShadow({mode: 'open'});
        this.state = {
            message: message,
            time: time,
        };
        this.applyTemplate();
        this.attachStyling();
        this.setState('message', message);
        this.setState('time', time);
    }

    connectedCallback() {
        console.log('sendermessage: connected to DOM');
    }

    disconnectedCallback(){
        console.log('sendermessage: disconnected from DOM');
    }

    applyTemplate() {
        let template = document.getElementById(this.templateId);
        let clone = template.content.cloneNode(true);
        this.shadowRoot.appendChild(clone);
    }

    attachStyling(){
        const linkElem = document.createElement("link");
        linkElem.setAttribute("rel", "stylesheet");
        linkElem.setAttribute("href", "/css/components/senderMessage.css");
        this.shadowRoot.appendChild(linkElem);
    }

    setState(key, value) {
        this.state[key] = value;
        this.updateBinding(key);
    }

    updateBinding(prop) {
        let bindings = this.shadowRoot.querySelectorAll(`[data-bind$="${prop}"]`);
        bindings.forEach(node => {
            node.textContent = this.state[prop];
        })
    }
}

//define and export component
customElements.define('sender-message', SenderMessage);
export {SenderMessage};
