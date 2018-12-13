import { html } from '@polymer/lit-element';
import { PageViewElement } from '../page-view-element';
import { connect } from 'pwa-helpers/connect-mixin';
import { store } from '../../store';
import { crewsSelector } from '../../reducers/crews';
import { getCrewAthletes } from '../../actions/athletes';
import { getCrewAwards } from '../../actions/awards';
import { repeat } from 'lit-html/directives/repeat';
import { CardTableStyles } from '../card-table-styles';
import '../basic-card';

import './results-card';
import './penalties-card';
import './awards-card';

import crews from '../../reducers/crews';
import athletes from '../../reducers/athletes';
store.addReducers({
    crews, athletes
});

class CrewView extends connect(store)(PageViewElement) {
  render() {
      return html`
        <link rel="stylesheet" href="/dist/site.css">
        ${CardTableStyles}

        <basic-card headline="Crew Details">
        <div slot="content">
            <div>${this._crew.name}</div>
            <div>Competition: <a href=${this._compLink}>${this._competitionName}</a></div>
            <div>Start Number: ${this._crew.startNumber}</div>
            <div>CRI Max: ${this._crew.criMax}</div>
        </div>
        </basic-card>

        <basic-card headline="Athletes">
            <table slot="content">
                <thead>
                    <tr><th>Seat</th><th>Name</th><th>PRI</th><th>PRIMax</th></tr>
                </thead>
                <tbody>
                    ${this._athletes && repeat(this._athletes, (athlete) =>
                    html`
                        <tr>
                            <td>${this._positionText(athlete.position)}</td>
                            <td>${athlete.firstName} ${athlete.lastName}</td>
                            <td>${athlete.pri}</td>
                            <td>${athlete.priMax}</td>
                        </tr>
                    `)}
                </tbody>
            </table>
        </basic-card>

        <results-card crewId=${this._crew.id}></results-card>

        <penalties-card crewId=${this._crew.id}></penalties-card>

        <awards-card crewId=${this._crew.id}></awards-card>
       `;
    }

    static get properties() {
        return {
            _crew: { type: Object },
            _competitionName: { type: String },
            _compLink: { type: String },
            _athletes: { type: Array }
        };
    }

    _positionText(position) {
        switch (this._crew.boatClass) {
            case 7:
                switch (position) {
                    case 1:
                        return "Bow";
                    case 8:
                        return "Stroke";
                    case 9:
                        return "Cox";
                    default:
                        return position;
                }
            default:
                return position;
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

export { getCrewAthletes, getCrewAwards };