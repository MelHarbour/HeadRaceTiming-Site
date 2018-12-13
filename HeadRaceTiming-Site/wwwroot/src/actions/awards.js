export const RECEIVE_AWARDS = 'RECEIVE_AWARDS';
export const RECEIVE_CREW_AWARDS = 'RECEIVE_CREW_AWARDS';

export const getCompetitionAwards = (id) => (dispatch) => {
    fetch('/api/competitions/'+id+'/awards')
        .then(res => res.json())
        .then(data => dispatch(receiveAwards(data)));
};

export const getCrewAwards = (id) => (dispatch) => {
    fetch('/api/crews/' + id + '/awards')
        .then(res => res.json())
        .then(data => dispatch(receiveCrewAwards(data, id)));
};

const receiveAwards = (items) => {
    return {
        type: RECEIVE_AWARDS,
        awards: items
    };
};

const receiveCrewAwards = (items, id) => {
    return {
        type: RECEIVE_CREW_AWARDS,
        awards: items,
        crewId: id
    };
};