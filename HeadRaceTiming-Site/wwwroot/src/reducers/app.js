import {
  UPDATE_PAGE,
  UPDATE_OFFLINE
} from '../actions/app.js';

const INITIAL_STATE = {
    page: '',
    focussedCrew: '',
    focussedCompetition: '',
  offline: false
};

const app = (state = INITIAL_STATE, action) => {
  switch (action.type) {
      case UPDATE_PAGE:
          switch (action.page) {
              case 'results':
                  return {
                      ...state,
                      page: action.page,
                      focussedCompetition: action.id
                  };
              case 'crew':
                  return {
                      ...state,
                      page: action.page,
                      focussedCrew: action.id
                  };
              default:
                  return {
                      ...state,
                      page: action.page
                  };
          }
    case UPDATE_OFFLINE:
      return {
        ...state,
        offline: action.offline
      };
    default:
      return state;
  }
};

export default app;
