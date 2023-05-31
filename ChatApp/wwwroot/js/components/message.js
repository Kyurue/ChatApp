class Message extends HTMLElement {

    //start shadowroot <- is this necessary?
    shadowRoot;
    templateId = 'chat-message-tpl';
    elementId = 'chat-message';

    //initialize component (constructor)
    constructor(message, time, user) {
        super();
        this.shadowRoot = this.attachShadow({mode: 'open'});
        this.state = {
            message: message,
            user: user,
            time: time,
        };
        this.applyTemplate();
        this.attachStyling();
        this.setState('message', message);
        this.setState('user', user);
        this.setState('time', time);
    }

    connectedCallback() {
        console.log('message: connected to DOM');
    }

    disconnectedCallback(){
        console.log('message: disconnected from DOM');
    }

    applyTemplate() {
        let template = document.getElementById(this.templateId);
        let clone = template.content.cloneNode(true);
        this.shadowRoot.appendChild(clone);
    }

    attachStyling(){
        const linkElem = document.createElement("link");
        linkElem.setAttribute("rel", "stylesheet");
        linkElem.setAttribute("href", "/css/components/message.css");
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
customElements.define('chat-message', Message);
export {Message};
