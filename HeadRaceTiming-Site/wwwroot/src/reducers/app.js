import {
  UPDATE_PAGE,
  UPDATE_OFFLINE
} from '../actions/app.js';

const INITIAL_STATE = {
    page: '',
    id: '',
  offline: false
};

const app = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case UPDATE_PAGE:
      return {
        ...state,
          page: action.page,
          id: action.id
      };
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
