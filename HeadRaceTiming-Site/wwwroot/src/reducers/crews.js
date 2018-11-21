import { RECEIVE_CREWS } from '../actions/crews.js';
import { createSelector } from 'reselect';

const INITIAL_STATE = {
    crews: {},
    orderedCrews: []
};

const crews = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case RECEIVE_CREWS:
            return {
                ...state,
                crews: action.crews.reduce((obj, item) => {
                    obj[item.id] = item;
                    return obj;
                }, {}),
                orderedCrews: action.crews.map(item => item.id)
            };
        default:
            return state;
    }
};

export default crews;

export const crewsSelector = state => state.crews && state.crews.crews;
const orderedCrewsSelector = state => state.crews && state.crews.orderedCrews;

export const crewsListSelector = createSelector(
    crewsSelector, orderedCrewsSelector,
    (crews, order) => {
        if (!crews) {
            return;
        }
        return order.map(key => crews[key]);
    }
);