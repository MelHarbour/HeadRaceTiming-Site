export const RECEIVE_COMPETITIONS = 'RECEIVE_COMPETITIONS';
export const RECEIVE_COMPETITION = 'RECEIVE_COMPETITION';

export const getAllCompetitions = () => (dispatch) => {
    fetch('/api/competitions')
        .then(res => res.json())
        .then(data => dispatch(receiveCompetitions(data)));
};

export function getCompetition(id) {
    return dispatch => {
        return fetch('/api/competitions/' + id)
            .then(res => res.json())
            .then(response => {
                dispatch(receiveCompetition(response));
            });
    };
}

const receiveCompetition = (item) => {
    return {
        type: RECEIVE_COMPETITION,
        competition: item
    };
};

const receiveCompetitions = (items) => {
    return {
        type: RECEIVE_COMPETITIONS,
        competitions: items
    };
};