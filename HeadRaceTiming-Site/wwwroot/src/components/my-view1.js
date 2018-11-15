import { PageViewElement } from './page-view-element.js';

class MyView1 extends PageViewElement {
  render() {
    return html`

    `;
  }
}

window.customElements.define('my-view1', MyView1);
