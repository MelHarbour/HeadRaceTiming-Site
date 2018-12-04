export const RECEIVE_AWARDS = 'RECEIVE_AWARDS';

export const getCompetitionAwards = (id) => (dispatch) => {
    fetch('/api/competitions/'+id+'/awards')
        .then(res => res.json())
        .then(data => dispatch(receiveAwards(data)));
};

const receiveAwards = (items) => {
    return {
        type: RECEIVE_AWARDS,
        awards: items
    };
};