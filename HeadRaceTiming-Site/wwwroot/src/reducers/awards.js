import { RECEIVE_AWARDS, RECEIVE_CREW_AWARDS } from '../actions/awards';

const INITIAL_STATE = {
    awards: {}
};

const awards = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case RECEIVE_AWARDS:
        case RECEIVE_CREW_AWARDS:
            return {
                ...state,
                awards: action.awards.reduce((obj, item) => {
                    obj[item.id] = item;
                    return obj;
                }, state.awards)
            };
        default:
            return state;
    }
};

export default awards;