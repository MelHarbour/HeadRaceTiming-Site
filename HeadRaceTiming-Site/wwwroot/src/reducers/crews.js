﻿import { RECEIVE_CREWS, RECEIVE_CREW } from '../actions/crews';
import { RECEIVE_CREW_AWARDS } from '../actions/awards';
import { createSelector } from 'reselect';
import { RECEIVE_PENALTIES } from '../actions/penalties';

const INITIAL_STATE = {
    crews: {},
    crewsByAward: {}
};

const crews = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case RECEIVE_CREWS:
            return {
                ...state,
                crews: action.crews.reduce((obj, item) => {
                    if (state.crews[item.id]) {
                        obj[item.id] = {
                            ...state.crews[item.id],
                            item
                        }
                    } else {
                        obj[item.id] = item;
                    }
                    return obj;
                }, state.crews),
                crewsByAward: {
                    ...state.crewsByAward,
                    [action.awardId]: {
                        ...state.crewsByAward[action.awardId], 
                        [action.searchString]: action.crews.map(item => item.id)
                    }
                }
            };
        case RECEIVE_CREW:
            return {
                ...state,
                crews: {
                    ...state.crews,
                    [action.crew.id]: action.crew
                },
            };
        case RECEIVE_CREW_AWARDS:
            var crew = {
                ...state.crews[action.crewId],
                awards: action.awards.map(award => award.id)
            };
            return {
                ...state,
                crews: Object.keys(state.crews).reduce(function (result, key) {
                    result[key] = action.crewId !== key ? state.crews[key] : { ...state.crews[key], ...crew };
                    return result;
                }, {})
            };
        case RECEIVE_PENALTIES:
            crew = {
                ...state.crews[action.crewId],
                penalties: action.penalties.map(penalty => penalty.id)
            };
            return {
                ...state,
                crews: Object.keys(state.crews).reduce(function (result, key) {
                    result[key] = action.crewId !== key ? state.crews[key] : { ...state.crews[key], ...crew };
                    return result;
                }, {})
            };
        default:
            return state;
    }
};

export default crews;

export const crewsSelector = state => state.crews && state.crews.crews;