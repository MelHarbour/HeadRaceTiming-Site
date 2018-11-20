export const RECEIVE_RESULTS = 'RECEIVE_RESULTS';

export const getCompetitionResults = () => (dispatch) => {
    fetch('/api/competitions')
        .then(res => res.json())
        .then(data => dispatch(receiveResults(data)));
};

const receiveResults = (items) => {
    return {
        type: RECEIVE_RESULTS,
        results: items
    };
};