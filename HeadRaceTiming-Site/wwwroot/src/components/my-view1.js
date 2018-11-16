import { html } from '@polymer/lit-element';
import { PageViewElement } from './page-view-element.js';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../store.js';
import { repeat } from 'lit-html/directives/repeat.js';

import counter from '../reducers/counter.js';
import competitions from '../reducers/competitions.js';
store.addReducers({
    competitions,
    counter
});


class MyView1 extends connect(store)(PageViewElement) {
  render() {
      return html`
        <div>${this._value}</div>

        ${this._competitions && repeat(this._competitions, (competition) =>
        html`
        <div class="mdc-card competitionCard" style="background-color: #@item.BackgroundHtmlColor" data-competition-id="@item.FriendlyName">
            <div class="mdc-card__primary-action">
                @if (String.IsNullOrEmpty(item.ImageUriText))
                {
                    <div class="mdc-typography--headline6" style="color: #@item.TextHtmlColor">@item.Name</div>
                }
                else
                {
                    <div class="mdc-card__media" style="background-image: url('@item.ImageUriText')">
                        <div class="mdc-card__media-content mdc-typography--headline6" style="color: #@item.TextHtmlColor">@item.Name</div>
                    </div>
                }
            </div>
        </div>
       `)}`;
    }

    static get properties() {
        return {
            _value: {type: Number },
            _competitions: { type: Array }
        };
    }

    stateChanged(state) {
        this._competitions = state.competitions.competitions;
        this._value = state.counter.value;
    }
}

window.customElements.define('my-view1', MyView1);