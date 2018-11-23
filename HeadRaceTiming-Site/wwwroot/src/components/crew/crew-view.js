import { html } from '@polymer/lit-element';
import { PageViewElement } from '../page-view-element.js';
import { connect } from 'pwa-helpers/connect-mixin.js';
import { store } from '../../store.js';
import { crewsSelector } from '../../reducers/crews.js';
import { getCrewAthletes } from '../../actions/athletes.js';
import { repeat } from 'lit-html/directives/repeat.js';

import crews from '../../reducers/crews.js';
import athletes from '../../reducers/athletes.js';
store.addReducers({
    crews, athletes
});

class CrewView extends connect(store)(PageViewElement) {
  render() {
      return html`
        <link rel="stylesheet" href="/dist/site.css">
        <style>
.mdc-card {
    margin: 16px;
}
table {
    border-spacing: 0;
    border-collapse: collapse;
    width: 100%;
}

tr, td {
    border-bottom: 1px rgba(0, 0, 0, 0.12) solid;
}

tr {
    height: 48px;
}

td, th {
    text-align: left;
    padding-left: 56px;
    white-space: nowrap;
}

td:first-child, th:first-child {
    padding-left: 24px;
}

td:last-child, th:last-child {
    padding-right: 24px;
}
</style>

        <div class="mdc-card">
        <div class="mdc-card__primary-action">
        <div class="mdc-typography--headline6">Crew Details</div>
            <div>${this._crew.name}</div>
            <div>Competition: <a href=${this._compLink}>${this._competitionName}</a></div>
            <div>Start Number: ${this._crew.startNumber}</div>
            <div>CRI Max: ${this._crew.criMax}</div>
        </div>
        </div>

        <div class="mdc-card">
        <div class="mdc-card__primary-action">
        <div class="mdc-typography--headline6">Athletes</div>
            <table>
                <thead>
                    <tr><th>Seat</th><th>Name</th><th>PRI</th><th>PRIMax</th></tr>
                </thead>
                <tbody>
                    ${this._athletes && repeat(this._athletes, (athlete) =>
                    html`
                        <tr>
                            <td>${athlete.position}</td>
                            <td>${athlete.firstName} ${athlete.lastName}</td>
                            <td>${athlete.pri}</td>
                            <td>${athlete.priMax}</td>
                        </tr>
                    `)}
                </tbody>
            </table>
        </div>
        </div>

        <div class="mdc-card">
        <div class="mdc-card__primary-action">
        <div class="mdc-typography--headline6">Penalties</div>
            <table>
                <thead>
                    <tr><th>Amount</th><th>Reason</th></tr>
                </thead>
                <tbody>
                    ${this._penalties && repeat(this._penalties, (penalty) =>
                    html`
                    <tr>
                        <td>${penalty.value}</td>
                        <td>${penalty.reason}</td>
                    </tr>
                    `)}
                </tbody>
            </table>
        </div>
        </div>
       `;
    }

    static get properties() {
        return {
            _crew: { type: Object },
            _competitionName: { type: String },
            _compLink: { type: String },
            _athletes: { type: Array },
            _penalties: { type: Array }
        };
    }

    updated() {
        const state = store.getState();
        if (state.app.focussedCrew) {
            store.dispatch(getCrewAthletes(state.app.focussedCrew));
        }
    }

    stateChanged(state) {
        if (state.app.focussedCrew && crewsSelector(state)[state.app.focussedCrew]) {
            this._crew = crewsSelector(state)[state.app.focussedCrew];
            this._athletes = Object.values(state.athletes.athletes);
        }
        if (state.app.focussedCompetition) {
            this._compLink = "/results/"+state.app.focussedCompetition;
            const competitionId = state.competitions.competitionsByFriendlyName[state.app.focussedCompetition];
            this._competitionName = state.competitions.competitions[competitionId].name;
        }
    }
}

window.customElements.define('crew-view', CrewView);