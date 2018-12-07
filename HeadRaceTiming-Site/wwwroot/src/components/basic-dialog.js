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
                    <footer class="mdc-dialog__actions">
                        <button type="button" class="mdc-button mdc-dialog__button" data-mdc-dialog-action="accept">Ok</button>
                    </footer>
                </div>
            </div>
            <div class="mdc-dialog__scrim"></div>
            </div>
        `;
    }

    static get properties() {
        return {
            _dialog: { type: Object }
        };
    }

    open() {
        this._dialog.open();
    }

    firstUpdated() {
        this._dialog = new MDCDialog(this.shadowRoot.querySelector('.mdc-dialog'));
    }
}

customElements.define('basic-dialog', BasicDialog);