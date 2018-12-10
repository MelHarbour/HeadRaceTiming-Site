import { RECEIVE_COMPETITIONS, RECEIVE_COMPETITION } from '../actions/competitions';

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
        case RECEIVE_COMPETITION:
            return {
                ...state,
                competitions: { [action.competition.competitionId]: action.competition },
                competitionsByFriendlyName: { [action.competition.friendlyName]: action.competition.competitionId }
            };
        default:
            return state;
    }
};

export default competitions;