export const RECEIVE_ATHLETES = 'RECEIVE_ATHLETES';

export const getCrewAthletes = (id) => (dispatch) => {
    fetch('/api/crews/'+id+'/athletes')
        .then(res => res.json())
        .then(data => dispatch(receiveAthletes(data)));
};

const receiveAthletes = (items) => {
    return {
        type: RECEIVE_ATHLETES,
        athletes: items
    };
};