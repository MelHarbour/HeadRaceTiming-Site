import {
    UPDATE_PAGE,    APPLY_FILTER,
    UPDATE_SEARCH,
    APPLY_SEARCH,
    FETCHING
} from '../actions/app';

import {
    RECEIVE_COMPETITIONS
} from '../actions/competitions';

import {
    RECEIVE_CREWS
} from '../actions/crews';

const INITIAL_STATE = {
    page: '',
    focussedCrew: '',
    focussedCompetition: '',
    filterAward: '',
    searchString: '',
    showSearch: false,
    isLoading: false
};

const app = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case UPDATE_PAGE:
            switch (action.page) {
                case 'results':
                    return {
                        ...state,
                        page: action.page,
                        focussedCompetition: action.id,
                        showSearch: false
                    };
                case 'crew':
                    return {
                        ...state,
                        page: action.page,
                        focussedCrew: action.id,
                        showSearch: false
                    };
                default:
                    return {
                        ...state,
                        page: action.page,
                        showSearch: false
                    };
            }
        case APPLY_FILTER:
            return {
                ...state,
                filterAward: action.awardId
            };
        case APPLY_SEARCH:
            return {
                ...state,
                searchString: action.searchString
            }
        case UPDATE_SEARCH:
            return {
                ...state,
                showSearch: action.visible,
                searchString: ''
            };
        case FETCHING:
            return {
                ...state,
                isLoading: true
            };
        case RECEIVE_COMPETITIONS:
        case RECEIVE_CREWS:
            return {
                ...state,
                isLoading: false
            };
        default:
            return state;
    }
};

export default app;