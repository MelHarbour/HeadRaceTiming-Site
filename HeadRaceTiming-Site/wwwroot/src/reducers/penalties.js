import { RECEIVE_PENALTIES } from '../actions/penalties';

const INITIAL_STATE = {
    byId: {}
};

const penalties = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case RECEIVE_PENALTIES:
            return {
                ...state,
                byId: action.penalties
            };
        default:
            return state;
    }
};

export default penalties;