import { RECEIVE_RESULTS } from '../actions/results.js';

const INITIAL_STATE = {
    results: [
        {
            "name":"Crew 1"
        }
    ]
};

const results = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case RECEIVE_RESULTS:
            return {
                ...state,
                results: action.results
            };
        default:
            return state;
    }
};

export default results;