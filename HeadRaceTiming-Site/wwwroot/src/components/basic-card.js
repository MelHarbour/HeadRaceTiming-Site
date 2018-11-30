import { html, LitElement } from '@polymer/lit-element';

class BasicCard extends LitElement {
    render() {
        return html`
            <link rel="stylesheet" href="/dist/site.css">
            <style>
            .mdc-card {
                margin: 16px;
            }
            </style>
            <div class="mdc-card">
                <div class="mdc-card__primary-action">
                    <div class="mdc-typography--headline6">${this.headline}</div>
                    <slot name="content"></slot>
                </div>
            </div>
        `;
    }

    static get properties() {
        return {
            headline: { type: String }
        };
    }
}

customElements.define('basic-card', BasicCard);