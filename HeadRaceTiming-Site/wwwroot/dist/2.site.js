(window.webpackJsonp=window.webpackJsonp||[]).push([[2],{373:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.getCompetition=t.getCompetitionCrews=void 0;var r=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),i=O(['\n        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">\n        <style>\n            .header-row, .row {\n                display: flex;\n                line-height: 56px;\n                padding-left: 24px;\n                padding-right: 24px;\n                border-bottom: 1px rgba(0, 0, 0, 0.12) solid;\n            }\n            .header-row {\n                color: rgba(0,0,0,0.54);\n            }\n            .row {\n                color: rgba(0,0,0,0.87);\n            }\n            .row:hover {\n                background-color: #eeeeee;\n                cursor: pointer;\n            }\n            .name {\n                flex-grow: 1;\n                overflow: hidden;\n                text-overflow: ellipsis;\n                white-space: nowrap;\n            }\n            .startNumber {\n                width: 33px;\n                margin-right: 56px;\n            }\n            .intermediate, .time {\n                width: 100px;\n                text-align: center;\n                margin-left: 56px;\n            }\n            .intermediate {\n                display: none;\n            }\n            @media (min-width: 840px) {\n                .intermediate {\n                    display: block;\n                }\n            }\n        </style>\n        <div class="header-row">\n            <div class="startNumber">Start</div>\n            <div class="name">Crew Name</div>\n            <div class="intermediate">','</div>\n            <div class="intermediate">','</div>\n            <div class="time">Finish</div>\n        </div>\n        ',"\n        "],['\n        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">\n        <style>\n            .header-row, .row {\n                display: flex;\n                line-height: 56px;\n                padding-left: 24px;\n                padding-right: 24px;\n                border-bottom: 1px rgba(0, 0, 0, 0.12) solid;\n            }\n            .header-row {\n                color: rgba(0,0,0,0.54);\n            }\n            .row {\n                color: rgba(0,0,0,0.87);\n            }\n            .row:hover {\n                background-color: #eeeeee;\n                cursor: pointer;\n            }\n            .name {\n                flex-grow: 1;\n                overflow: hidden;\n                text-overflow: ellipsis;\n                white-space: nowrap;\n            }\n            .startNumber {\n                width: 33px;\n                margin-right: 56px;\n            }\n            .intermediate, .time {\n                width: 100px;\n                text-align: center;\n                margin-left: 56px;\n            }\n            .intermediate {\n                display: none;\n            }\n            @media (min-width: 840px) {\n                .intermediate {\n                    display: block;\n                }\n            }\n        </style>\n        <div class="header-row">\n            <div class="startNumber">Start</div>\n            <div class="name">Crew Name</div>\n            <div class="intermediate">','</div>\n            <div class="intermediate">','</div>\n            <div class="time">Finish</div>\n        </div>\n        ',"\n        "]),o=O(['\n            <div class="row" @click="','" data-crew-id=','>\n                <div class="startNumber">\n                    ','\n                </div>\n                <div class="name" title="','">\n                    ',"\n                    ",'\n                </div>\n                <div class="intermediate">\n                            \n                </div>\n                <div class="intermediate">\n                            \n                </div>\n                <div class="time">\n                    ',"\n                </div>\n            </div>\n       "],['\n            <div class="row" @click="','" data-crew-id=','>\n                <div class="startNumber">\n                    ','\n                </div>\n                <div class="name" title="','">\n                    ',"\n                    ",'\n                </div>\n                <div class="intermediate">\n                            \n                </div>\n                <div class="intermediate">\n                            \n                </div>\n                <div class="time">\n                    ',"\n                </div>\n            </div>\n       "]),a=O(['<span class="material-icons">rowing</span>'],['<span class="material-icons">rowing</span>']),s=O(["",""],["",""]),c=O(["\n                            ","","\n                            ","\n                    "],["\n                            ","","\n                            ","\n                    "]),u=O(["P"],["P"]),l=O(["(",")"],["(",")"]),d=n(144),p=n(377),f=n(145),m=n(146),v=n(378),w=n(381),h=C(w),y=C(n(383)),b=n(102),g=n(380),_=n(379),E=n(389);function C(e){return e&&e.__esModule?e:{default:e}}function O(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}m.store.addReducers({crews:h.default,competitions:y.default});var I=function(e){function t(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,(0,f.connect)(m.store)(p.PageViewElement)),r(t,[{key:"render",value:function(){var e=this;return(0,d.html)(i,this._firstIntermediateName,this._secondIntermediateName,this._crews&&(0,v.repeat)(this._crews,function(t){return(0,d.html)(o,function(t){return e.clickHandler(t)},t.id,t.startNumber,t.name,t.name,t.isStarted?(0,d.html)(a):null,t.status?(0,d.html)(s,e._statusCode(t.status)):(0,d.html)(c,t.overallTime,t.hasPenalty?(0,d.html)(u):null,t.overallTime?(0,d.html)(l,t.rank):null))}))}},{key:"_statusCode",value:function(e){switch(e){case 1:return"Missing";case 2:return"DNF";case 3:return"DSQ";case 4:return"DNS"}}},{key:"updated",value:function(){var e=this,t=m.store.getState();if(t.app.focussedCompetition&&!this._timeout){var n=t.competitions.competitionsByFriendlyName[t.app.focussedCompetition];this._timeout=(0,E.setTimeout)(function(){m.store.dispatch((0,g.getCompetitionCrews)(n)),e._timeout=null},1e4)}}},{key:"stateChanged",value:function(e){this._crews=(0,w.crewsListSelector)(e)}},{key:"clickHandler",value:function(e){window.history.pushState({},"","/crew/"+e.currentTarget.dataset.crewId),m.store.dispatch((0,b.navigate)(window.location.pathname))}}],[{key:"properties",get:function(){return{_crews:{type:Array},_firstIntermediateName:{type:String},_secondIntermediateName:{type:String},_timeout:{type:Number}}}}]),t}();window.customElements.define("results-view",I),t.getCompetitionCrews=g.getCompetitionCrews,t.getCompetition=_.getCompetition},377:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.PageViewElement=void 0;var r=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),i=n(144);t.PageViewElement=function(e){function t(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,i.LitElement),r(t,[{key:"shouldUpdate",value:function(){return this.active}}],[{key:"properties",get:function(){return{active:{type:Boolean}}}}]),t}()},379:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.getCompetition=function(e){return function(t){return fetch("/api/competitions/"+e).then(function(e){return e.json()}).then(function(e){t(o(e))})}};var r=t.RECEIVE_COMPETITIONS="RECEIVE_COMPETITIONS",i=t.RECEIVE_COMPETITION="RECEIVE_COMPETITION";t.getAllCompetitions=function(){return function(e){fetch("/api/competitions").then(function(e){return e.json()}).then(function(t){return e(a(t))})}};var o=function(e){return{type:i,competition:e}},a=function(e){return{type:r,competitions:e}}},380:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_CREWS="RECEIVE_CREWS",i=(t.getCompetitionCrews=function(e){return function(t){fetch("/api/competitions/"+e+"/crews").then(function(e){return e.json()}).then(function(e){return t(i(e))})}},function(e){return{type:r,crews:e}})},381:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.crewsListSelector=t.crewsSelector=void 0;var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},i=n(380),o=n(382),a={crews:{},orderedCrews:[]};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:a,t=arguments[1];switch(t.type){case i.RECEIVE_CREWS:return r({},e,{crews:t.crews.reduce(function(e,t){return e[t.id]=t,e},{}),orderedCrews:t.crews.map(function(e){return e.id})});default:return e}};var s=t.crewsSelector=function(e){return e.crews&&e.crews.crews};t.crewsListSelector=(0,o.createSelector)(s,function(e){return e.crews&&e.crews.orderedCrews},function(e,t){if(e)return t.map(function(t){return e[t]})})},383:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},i=n(379);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}var a={competitions:[],competitionsByFriendlyName:{}};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:a,t=arguments[1];switch(t.type){case i.RECEIVE_COMPETITIONS:return r({},e,{competitions:t.competitions.reduce(function(e,t){return e[t.competitionId]=t,e},{}),competitionsByFriendlyName:t.competitions.reduce(function(e,t){return e[t.friendlyName]=t.competitionId,e},{})});case i.RECEIVE_COMPETITION:return console.log(t),r({},e,{competitions:o({},t.competition.competitionId,t.competition),competitionsByFriendlyName:o({},t.competition.friendlyName,t.competition.competitionId)});default:return e}}}}]);