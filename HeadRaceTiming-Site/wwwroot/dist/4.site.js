(window.webpackJsonp=window.webpackJsonp||[]).push([[4],{404:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.getCompetition=t.getCompetitionCrews=void 0;var r=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),i=k(['\n        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">\n        <style>\n            .header-row, .row {\n                display: flex;\n                line-height: 56px;\n                padding-left: 24px;\n                padding-right: 24px;\n                border-bottom: 1px rgba(0, 0, 0, 0.12) solid;\n            }\n            .header-row {\n                color: rgba(0,0,0,0.54);\n            }\n            .row {\n                color: rgba(0,0,0,0.87);\n            }\n            .row:hover {\n                background-color: #eeeeee;\n                cursor: pointer;\n            }\n            .name {\n                flex-grow: 1;\n                overflow: hidden;\n                text-overflow: ellipsis;\n                white-space: nowrap;\n            }\n            .startNumber {\n                width: 33px;\n                margin-right: 56px;\n            }\n            .intermediate, .time {\n                width: 100px;\n                text-align: center;\n                margin-left: 56px;\n            }\n            .intermediate {\n                display: none;\n            }\n            @media (min-width: 840px) {\n                .intermediate {\n                    display: block;\n                }\n            }\n        </style>\n        <div class="header-row">\n            <div class="startNumber">Start</div>\n            <div class="name">Crew Name</div>\n            <div class="intermediate">','</div>\n            <div class="intermediate">','</div>\n            <div class="time">Finish</div>\n        </div>\n        ',"\n        "],['\n        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">\n        <style>\n            .header-row, .row {\n                display: flex;\n                line-height: 56px;\n                padding-left: 24px;\n                padding-right: 24px;\n                border-bottom: 1px rgba(0, 0, 0, 0.12) solid;\n            }\n            .header-row {\n                color: rgba(0,0,0,0.54);\n            }\n            .row {\n                color: rgba(0,0,0,0.87);\n            }\n            .row:hover {\n                background-color: #eeeeee;\n                cursor: pointer;\n            }\n            .name {\n                flex-grow: 1;\n                overflow: hidden;\n                text-overflow: ellipsis;\n                white-space: nowrap;\n            }\n            .startNumber {\n                width: 33px;\n                margin-right: 56px;\n            }\n            .intermediate, .time {\n                width: 100px;\n                text-align: center;\n                margin-left: 56px;\n            }\n            .intermediate {\n                display: none;\n            }\n            @media (min-width: 840px) {\n                .intermediate {\n                    display: block;\n                }\n            }\n        </style>\n        <div class="header-row">\n            <div class="startNumber">Start</div>\n            <div class="name">Crew Name</div>\n            <div class="intermediate">','</div>\n            <div class="intermediate">','</div>\n            <div class="time">Finish</div>\n        </div>\n        ',"\n        "]),o=k(['\n            <div class="row" @click="','" data-crew-id=','>\n                <div class="startNumber">\n                    ','\n                </div>\n                <div class="name" title="','">\n                    ',"\n                    ",'\n                </div>\n                <div class="intermediate">\n                    ','\n                </div>\n                <div class="intermediate">\n                    ','\n                </div>\n                <div class="time">\n                    ',"\n                </div>\n            </div>\n       "],['\n            <div class="row" @click="','" data-crew-id=','>\n                <div class="startNumber">\n                    ','\n                </div>\n                <div class="name" title="','">\n                    ',"\n                    ",'\n                </div>\n                <div class="intermediate">\n                    ','\n                </div>\n                <div class="intermediate">\n                    ','\n                </div>\n                <div class="time">\n                    ',"\n                </div>\n            </div>\n       "]),s=k(['<span class="material-icons">rowing</span>'],['<span class="material-icons">rowing</span>']),a=k(["\n                        ","\n                        ","\n                    "],["\n                        ","\n                        ","\n                    "]),c=k(["\n                            (",")\n                        "],["\n                            (",")\n                        "]),u=k(["\n                        ","        \n                        ","\n                    "],["\n                        ","        \n                        ","\n                    "]),d=k(["",""],["",""]),l=k(["\n                            ","","\n                            ","\n                    "],["\n                            ","","\n                            ","\n                    "]),p=k(["P"],["P"]),f=k(["(",")"],["(",")"]),m=n(164),w=n(411),h=n(165),v=n(166),_=n(410),g=n(418),y=S(g),b=S(n(167)),E=n(110),C=n(415),I=n(168),P=n(431);function S(e){return e&&e.__esModule?e:{default:e}}function k(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}function O(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function j(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}v.store.addReducers({crews:y.default,competitions:b.default});var x=function(e){function t(){return O(this,t),j(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,e),r(t,[{key:"render",value:function(){var e=this;return(0,m.html)(i,this._firstIntermediateName,this._secondIntermediateName,this._crews&&(0,_.repeat)(this._crews,(function(t){return(0,m.html)(o,(function(t){return e.clickHandler(t)}),t.id,t.startNumber,t.name,t.name,t.isStarted?(0,m.html)(s):null,t.status?null:(0,m.html)(a,e._getTime(t,e._firstIntermediatePoint),e._getTime(t,e._firstIntermediatePoint)?(0,m.html)(c,e._getRank(t,e._firstIntermediatePoint)):null),t.status?null:(0,m.html)(u,e._getTime(t,e._secondIntermediatePoint),e._getTime(t,e._secondIntermediatePoint)?(0,m.html)(c,e._getRank(t,e._secondIntermediatePoint)):null),t.status?(0,m.html)(d,e._statusCode(t.status)):(0,m.html)(l,t.overallTime,t.hasPenalty?(0,m.html)(p):null,t.overallTime?(0,m.html)(f,t.rank):null))})))}},{key:"_statusCode",value:function(e){switch(e){case 1:return"Missing";case 2:return"DNF";case 3:return"DSQ";case 4:return"DNS"}}},{key:"_getTime",value:function(e,t){for(var n=0;n<e.results.length;n++)if(e.results[n].id===t)return e.results[n].runTime}},{key:"_getRank",value:function(e,t){for(var n=0;n<e.results.length;n++)if(e.results[n].id===t)return e.results[n].rank}},{key:"updated",value:function(){var e=this,t=v.store.getState();if(t.app.focussedCompetition&&!this._timeout){var n=t.competitions.competitionsByFriendlyName[t.app.focussedCompetition];this._timeout=(0,P.setTimeout)((function(){v.store.dispatch((0,C.getCompetitionCrews)(n,e._filterAwardId,e._searchString)),e._timeout=null}),1e4)}}},{key:"stateChanged",value:function(e){if(e.app.focussedCompetition){var t=e.competitions.competitionsByFriendlyName[e.app.focussedCompetition];e.app.filterAward===this._filterAwardId&&e.app.searchString===this._searchString||null===this._timeout||((0,P.clearTimeout)(this._timeout),v.store.dispatch((0,C.getCompetitionCrews)(t,e.app.filterAward,e.app.searchString))),this._crews=(0,g.crewsListSelector)(e),this._filterAwardId=e.app.filterAward,this._searchString=e.app.searchString,this._firstIntermediateName=e.competitions.competitions[t].firstIntermediateName,this._firstIntermediatePoint=e.competitions.competitions[t].firstIntermediateId,this._secondIntermediateName=e.competitions.competitions[t].secondIntermediateName,this._secondIntermediatePoint=e.competitions.competitions[t].secondIntermediateId}}},{key:"clickHandler",value:function(e){window.history.pushState({},"","/crew/"+e.currentTarget.dataset.crewId),v.store.dispatch((0,E.navigate)(window.location.pathname))}}],[{key:"properties",get:function(){return{_crews:{type:Array},_firstIntermediateName:{type:String},_secondIntermediateName:{type:String},_firstIntermediatePoint:{type:Number},_secondIntermediatePoint:{type:Number},_timeout:{type:Number},_filterAwardId:{type:Number},_searchString:{type:String}}}}]),t}((0,h.connect)(v.store)(w.PageViewElement));window.customElements.define("results-view",x),t.getCompetitionCrews=C.getCompetitionCrews,t.getCompetition=I.getCompetition},411:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.PageViewElement=void 0;var r=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),i=n(164);function o(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function s(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}t.PageViewElement=function(e){function t(){return o(this,t),s(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,e),r(t,[{key:"shouldUpdate",value:function(){return this.active}}],[{key:"properties",get:function(){return{active:{type:Boolean}}}}]),t}(i.LitElement)},412:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_AWARDS="RECEIVE_AWARDS",i=t.RECEIVE_CREW_AWARDS="RECEIVE_CREW_AWARDS",o=(t.getCompetitionAwards=function(e){return function(t){fetch("/api/competitions/"+e+"/awards").then((function(e){return e.json()})).then((function(e){return t(o(e))}))}},t.getCrewAwards=function(e){return function(t){fetch("/api/crews/"+e+"/awards").then((function(e){return e.json()})).then((function(n){return t(s(n,e))}))}},function(e){return{type:r,awards:e}}),s=function(e,t){return{type:i,awards:e,crewId:t}}},414:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_PENALTIES="RECEIVE_PENALTIES",i=(t.getCrewPenalties=function(e){return function(t){fetch("/api/crews/"+e+"/penalties").then((function(e){return e.json()})).then((function(n){return t(i(n,e))}))}},function(e,t){return{type:r,penalties:e,crewId:t}})},415:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_CREWS="RECEIVE_CREWS",i=(t.getCompetitionCrews=function(e,t,n){return function(r){var o=t>0?"award="+t:"";n&&(""!=o&&(o+="&"),o+="s="+n),fetch("/api/competitions/"+e+"/crews"+(""!=o?"?"+o:"")).then((function(e){return e.json()})).then((function(e){return r(i(e))}))}},function(e){return{type:r,crews:e}})},418:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.crewsListSelector=t.crewsSelector=void 0;var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},i=n(415),o=n(412),s=n(413),a=n(414),c={crews:{},orderedCrews:[]};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:c,t=arguments[1];switch(t.type){case i.RECEIVE_CREWS:return r({},e,{crews:t.crews.reduce((function(t,n){return t[n.id]=n,e.crews[n.id]&&(t[n.id].awards=e.crews[n.id].awards),t}),{}),orderedCrews:t.crews.map((function(e){return e.id}))});case o.RECEIVE_CREW_AWARDS:var n=r({},e.crews[t.crewId],{awards:t.awards.map((function(e){return e.id}))});return r({},e,{crews:Object.keys(e.crews).reduce((function(i,o){return i[o]=t.crewId!==o?e.crews[o]:r({},e.crews[o],n),i}),{})});case a.RECEIVE_PENALTIES:return n=r({},e.crews[t.crewId],{penalties:t.penalties.map((function(e){return e.id}))}),r({},e,{crews:Object.keys(e.crews).reduce((function(i,o){return i[o]=t.crewId!==o?e.crews[o]:r({},e.crews[o],n),i}),{})});default:return e}};var u=t.crewsSelector=function(e){return e.crews&&e.crews.crews};t.crewsListSelector=(0,s.createSelector)(u,(function(e){return e.crews&&e.crews.orderedCrews}),(function(e,t){if(e)return t.map((function(t){return e[t]}))}))}}]);