export const RECEIVE_RESULTS = 'RECEIVE_RESULTS';

export const getCrewResults = (id) => (dispatch) => {
    fetch('/api/crews/'+id+'/results')
        .then(res => res.json())
        .then(data => dispatch(receiveResults(data)));
};

const receiveResults = (items) => {
    return {
        type: RECEIVE_RESULTS,
        results: items
    };
};