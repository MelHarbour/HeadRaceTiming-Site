import { html } from '@polymer/lit-element';
import { PageViewElement } from './page-view-element.js';

class MyView404 extends PageViewElement {
  render() {
      return html`
    `;
  }
}

window.customElements.define('my-view404', MyView404);