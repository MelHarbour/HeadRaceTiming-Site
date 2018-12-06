import { html, LitElement } from '@polymer/lit-element';
import { MDCDialog } from '@material/dialog';

class BasicDialog extends LitElement {
    render() {
        return html`
            <link rel="stylesheet" href="/dist/site.css">
            <div class="mdc-dialog"
                role="alertdialog"
                aria-modal="true">
            <div class="mdc-dialog__container">
                <div class="mdc-dialog__surface">
                    <div class="mdc-dialog__content" id="my-dialog-content">
                        <slot name="content"></slot>
                    </div>
                </div>
            </div>
            <div class="mdc-dialog__scrim"></div>
            </div>
        `;
    }

    firstUpdated() {
        const dialog = new MDCDialog(this.shadowRoot.querySelector('.mdc-dialog'));
    }
}

customElements.define('basic-dialog', BasicDialog);