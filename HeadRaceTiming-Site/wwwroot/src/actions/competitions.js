export const RECEIVE_COMPETITIONS = 'RECEIVE_COMPETITIONS';

export const getAllCompetitions = () => (dispatch) => {
    fetch('/api/competitions')
        .then(res => res.json())
        .then(data => dispatch(receiveCompetitions(data)));
};

const receiveCompetitions = (items) => {
    return {
        type: RECEIVE_COMPETITIONS,
        competitions: items
    };
};