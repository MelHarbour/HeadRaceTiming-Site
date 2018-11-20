import { RECEIVE_CREWS } from '../actions/crews.js';

const INITIAL_STATE = {
    crews: []
};

const crews = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case RECEIVE_CREWS:
            return {
                ...state,
                crews: action.crews
            };
        default:
            return state;
    }
};

export default crews;