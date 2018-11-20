import { html } from '@polymer/lit-element';
import { PageViewElement } from '../page-view-element.js';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../../store.js';
import { repeat } from 'lit-html/directives/repeat.js';

import results from '../../reducers/results.js';
import { getCompetitionResults } from '../../actions/results.js';
store.addReducers({
    results
});

class ResultsView extends connect(store)(PageViewElement) {
  render() {
      return html`
        <style>
            .header-row, .row {
                display: flex;
                line-height: 56px;
                padding-left: 24px;
                padding-right: 24px;
                border-bottom: 1px rgba(0, 0, 0, 0.12) solid;
            }
            .header-row {
                color: rgba(0,0,0,0.54);
            }
            .row {
                color: rgba(0,0,0,0.87);
            }
            .row:hover {
                background-color: #eeeeee;
                cursor: pointer;
            }
            .name {
                flex-grow: 1;
                overflow: hidden;
                text-overflow: ellipsis;
                white-space: nowrap;
            }
            .startNumber {
                width: 33px;
                margin-right: 56px;
            }
            .intermediate, .time {
                width: 100px;
                text-align: center;
                margin-left: 56px;
            }
        </style>
        <div class="header-row">
            <div class="startNumber">Start</div>
            <div class="name">Crew Name</div>
            <div class="intermediate">${this._firstIntermediateName}</div>
            <div class="intermediate">${this._secondIntermediateName}</div>
            <div class="time">Finish</div>
        </div>
        ${this._results && repeat(this._results, (result) => 
          html`
            <div class="row">
                <div class="startNumber">
                    ${result.startNumber}
                </div>
                <div class="name" title="[[item.name]]">
                    ${result.name}
                </div>
                <div class="intermediate">
                            
                </div>
                <div class="intermediate">
                            
                </div>
                <div class="time">
                    ${result.status
                        ? html`${result.status}`
                        : html`
                            ${result.overallTime}${result.hasPenalty ? html`P` : html``}
                            ${result.overallTime ? html`(${result.rank})` :html``}
                    `}
                </div>
            </div>
       `)}`;
    }
    static get properties() {
        return {
            _results: { type: Array },
            _firstIntermediateName: { type: String },
            _secondIntermediateName: { type: String }
        };
    }

    stateChanged(state) {
        this._results = state.results.results;
    }
}

window.customElements.define('results-view', ResultsView);