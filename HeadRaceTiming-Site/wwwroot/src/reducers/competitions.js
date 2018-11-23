import { RECEIVE_COMPETITIONS } from '../actions/competitions.js';

const INITIAL_STATE = {
    competitions: [],
    competitionsByFriendlyName: {}
};

const competitions = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case RECEIVE_COMPETITIONS:
            return {
                ...state,
                competitions: action.competitions.reduce((obj, item) => {
                    obj[item.competitionId] = item;
                    return obj;
                }, {}),
                competitionsByFriendlyName: action.competitions.reduce((obj, item) => {
                    obj[item.friendlyName] = item.competitionId;
                    return obj;
                }, {})
            };
        default:
            return state;
    }
};

export default competitions;