export const GET_COMPETITIONS = 'GET_COMPETITIONS';

const COMPETITIONS_LIST = [
    {
        "id": 1,
        "title": "WEHoRR 2018",
        "friendlyName": "wehorr2018",
        "backgroundColor": "0000FF",
        "textColor": "FFFFFF"
    }
];

export const getAllCompetitions = () => (dispatch) => {
    const competitions = COMPETITIONS_LIST.reduce((obj, competition) => {
        obj[competition.id] = competition;
        return obj;
    });

    dispatch({
        type: GET_COMPETITIONS,
        competitions
    });
};