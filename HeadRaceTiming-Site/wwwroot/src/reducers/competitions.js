import { GET_COMPETITIONS } from '../actions/competitions.js';

const INITIAL_STATE = {
    competitions: []
};

const competitions = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case GET_COMPETITIONS:
            return {
                ...state,
                competitions: action.competitions
            };
        default:
            return state;
    }
};

export default competitions;