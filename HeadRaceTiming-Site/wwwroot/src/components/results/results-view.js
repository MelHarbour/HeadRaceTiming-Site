import { html } from '@polymer/lit-element';
import { PageViewElement } from '../page-view-element.js';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../../store.js';
import { repeat } from 'lit-html/directives/repeat.js';

import crews from '../../reducers/crews.js';
import { crewsListSelector } from '../../reducers/crews.js';
import { navigate } from '../../actions/app.js';
import { getCompetitionCrews } from '../../actions/crews.js';
store.addReducers({
    crews
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
        ${this._crews && repeat(this._crews, (crew) =>
              html`
            <div class="row" @click="${(event) => this.clickHandler(event)}" data-crew-id=${crew.id}>
                <div class="startNumber">
                    ${crew.startNumber}
                </div>
                <div class="name" title="${crew.name}">
                    ${crew.name}
                </div>
                <div class="intermediate">
                            
                </div>
                <div class="intermediate">
                            
                </div>
                <div class="time">
                    ${crew.status
                      ? html`${crew.status}`
                      : html`
                            ${crew.overallTime}${crew.hasPenalty ? html`P` : null}
                            ${crew.overallTime ? html`(${crew.rank})` : null}
                    `}
                </div>
            </div>
       `)}
        `;
    }
    static get properties() {
        return {
            _crews: { type: Array },
            _firstIntermediateName: { type: String },
            _secondIntermediateName: { type: String }
        };
    }

    firstUpdated() {
        const state = store.getState();
        if (state.app.focussedCompetition) {
            const competitionId = state.competitions.competitionsByFriendlyName[state.app.focussedCompetition];
            store.dispatch(getCompetitionCrews(competitionId));
            setInterval(() => store.dispatch(getCompetitionCrews(competitionId)), 10000);
        }
    }

    stateChanged(state) {
        this._crews = crewsListSelector(state);
    }

    clickHandler(event) {
        window.history.pushState({}, '', '/crew/' + event.currentTarget.dataset.crewId);
        store.dispatch(navigate(window.location.pathname));
    }
}

window.customElements.define('results-view', ResultsView);