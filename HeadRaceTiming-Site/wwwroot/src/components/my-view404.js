import { html } from 'lit-element';
import { PageViewElement } from './page-view-element';

class MyView404 extends PageViewElement {
  render() {
      return html`
    `;
  }
}

window.customElements.define('my-view404', MyView404);
