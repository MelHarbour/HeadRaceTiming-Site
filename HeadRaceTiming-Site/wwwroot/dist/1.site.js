(window.webpackJsonp=window.webpackJsonp||[]).push([[1],{407:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.getCrew=t.getCrewPenalties=t.getCrewAwards=t.getCrewAthletes=void 0;var r=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),o=_(['\n        <link rel="stylesheet" href="/dist/site.css">\n        ','\n\n        <basic-card headline="Crew Details">\n        <div slot="content" style="padding: 1rem">\n            <div>',"</div>\n            <div>Competition: <a href=",">","</a></div>\n            <div>Start Number: ","</div>\n            <div>CRI Max: ",'</div>\n        </div>\n        </basic-card>\n\n        <basic-card headline="Certificate">\n        <div slot="content" style="padding: 1rem">\n        <a href="/Crew/Certificate?crewId=','" download>Download</a>\n        </div>\n        </basic-card>\n\n        <basic-card headline="Athletes">\n            <table slot="content">\n                <thead>\n                    <tr><th>Seat</th><th>Name</th><th>PRI</th><th>PRIMax</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n\n        <results-card crewId=","></results-card>\n\n        <penalties-card crewId=","></penalties-card>\n\n        <awards-card crewId=","></awards-card>\n       "],['\n        <link rel="stylesheet" href="/dist/site.css">\n        ','\n\n        <basic-card headline="Crew Details">\n        <div slot="content" style="padding: 1rem">\n            <div>',"</div>\n            <div>Competition: <a href=",">","</a></div>\n            <div>Start Number: ","</div>\n            <div>CRI Max: ",'</div>\n        </div>\n        </basic-card>\n\n        <basic-card headline="Certificate">\n        <div slot="content" style="padding: 1rem">\n        <a href="/Crew/Certificate?crewId=','" download>Download</a>\n        </div>\n        </basic-card>\n\n        <basic-card headline="Athletes">\n            <table slot="content">\n                <thead>\n                    <tr><th>Seat</th><th>Name</th><th>PRI</th><th>PRIMax</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n\n        <results-card crewId=","></results-card>\n\n        <penalties-card crewId=","></penalties-card>\n\n        <awards-card crewId=","></awards-card>\n       "]),i=_(["\n                        <tr>\n                            <td>","</td>\n                            <td>"," ","</td>\n                            <td>","</td>\n                            <td>","</td>\n                        </tr>\n                    "],["\n                        <tr>\n                            <td>","</td>\n                            <td>"," ","</td>\n                            <td>","</td>\n                            <td>","</td>\n                        </tr>\n                    "]),a=n(164),c=n(410),s=n(165),u=n(166),l=n(417),d=m(l),f=n(413),p=n(428),h=n(411),w=n(414),b=n(409),y=n(415);n(416),n(441),n(443),n(445);var v=m(n(446));function m(e){return e&&e.__esModule?e:{default:e}}function _(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}function E(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function g(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}u.store.addReducers({crews:d.default,athletes:v.default});var O=function(e){function t(){return E(this,t),g(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,e),r(t,[{key:"render",value:function(){var e=this;return(0,a.html)(o,y.CardTableStyles,this._crew.name,this._compLink,this._competitionName,this._crew.startNumber,this._crew.criMax,this._crew.id,this._athletes&&(0,b.repeat)(this._athletes,(function(t){return(0,a.html)(i,e._positionText(t.position),t.firstName,t.lastName,t.pri,t.priMax)})),this._crew.id,this._crew.id,this._crew.id)}},{key:"_positionText",value:function(e){switch(this._crew.boatClass){case 7:switch(e){case 1:return"Bow";case 8:return"Stroke";case 9:return"Cox";default:return e}default:return e}}},{key:"stateChanged",value:function(e){if(e.app.focussedCrew&&(0,l.crewsSelector)(e)[e.app.focussedCrew]&&(this._crew=(0,l.crewsSelector)(e)[e.app.focussedCrew],e.athletes.athletesByCrew[this._crew.id]&&(this._athletes=e.athletes.athletesByCrew[this._crew.id].map((function(t){return e.athletes.athletes[t]})))),e.app.focussedCompetition){this._compLink="/results/"+e.app.focussedCompetition;var t=e.competitions.competitionsByFriendlyName[e.app.focussedCompetition];this._competitionName=e.competitions.competitions[t].name}}}],[{key:"properties",get:function(){return{_crew:{type:Object},_competitionName:{type:String},_compLink:{type:String},_athletes:{type:Array}}}}]),t}((0,s.connect)(u.store)(c.PageViewElement));window.customElements.define("crew-view",O),t.getCrewAthletes=p.getCrewAthletes,t.getCrewAwards=h.getCrewAwards,t.getCrewPenalties=w.getCrewPenalties,t.getCrew=f.getCrew},409:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.repeat=void 0;var r=n(70),o=function(e,t){var n=e.startNode.parentNode,o=void 0===t?e.endNode:t.startNode,i=n.insertBefore((0,r.createMarker)(),o);n.insertBefore((0,r.createMarker)(),o);var a=new r.NodePart(e.options);return a.insertAfterNode(i),a},i=function(e,t){return e.setValue(t),e.commit(),e},a=function(e,t,n){var o=e.startNode.parentNode,i=n?n.startNode:e.endNode,a=t.endNode.nextSibling;a!==i&&(0,r.reparentNodes)(o,t.startNode,a,i)},c=function(e){(0,r.removeNodes)(e.startNode.parentNode,e.startNode,e.endNode.nextSibling)},s=function(e,t,n){for(var r=new Map,o=t;o<=n;o++)r.set(e[o],o);return r},u=new WeakMap,l=new WeakMap;t.repeat=(0,r.directive)((function(e,t,n){var d=void 0;return void 0===n?n=t:void 0!==t&&(d=t),function(t){if(!(t instanceof r.NodePart))throw new Error("repeat can only be used in text bindings");var f=u.get(t)||[],p=l.get(t)||[],h=[],w=[],b=[],y=0,v=!0,m=!1,_=void 0;try{for(var E,g=e[Symbol.iterator]();!(v=(E=g.next()).done);v=!0){var O=E.value;b[y]=d?d(O,y):y,w[y]=n(O,y),y++}}catch(e){m=!0,_=e}finally{try{!v&&g.return&&g.return()}finally{if(m)throw _}}for(var C=void 0,j=void 0,S=0,P=f.length-1,R=0,I=w.length-1;S<=P&&R<=I;)if(null===f[S])S++;else if(null===f[P])P--;else if(p[S]===b[R])h[R]=i(f[S],w[R]),S++,R++;else if(p[P]===b[I])h[I]=i(f[P],w[I]),P--,I--;else if(p[S]===b[I])h[I]=i(f[S],w[I]),a(t,f[S],h[I+1]),S++,I--;else if(p[P]===b[R])h[R]=i(f[P],w[R]),a(t,f[P],f[S]),P--,R++;else if(void 0===C&&(C=s(b,R,I),j=s(p,S,P)),C.has(p[S]))if(C.has(p[P])){var A=j.get(b[R]),T=void 0!==A?f[A]:null;if(null===T){var k=o(t,f[S]);i(k,w[R]),h[R]=k}else h[R]=i(T,w[R]),a(t,T,f[S]),f[A]=null;R++}else c(f[P]),P--;else c(f[S]),S++;for(;R<=I;){var N=o(t,h[I+1]);i(N,w[R]),h[R++]=N}for(;S<=P;){var x=f[S++];null!==x&&c(x)}u.set(t,h),l.set(t,b)}}))},410:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.PageViewElement=void 0;var r=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),o=n(164);function i(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function a(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}t.PageViewElement=function(e){function t(){return i(this,t),a(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,e),r(t,[{key:"shouldUpdate",value:function(){return this.active}}],[{key:"properties",get:function(){return{active:{type:Boolean}}}}]),t}(o.LitElement)},411:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_AWARDS="RECEIVE_AWARDS",o=t.RECEIVE_CREW_AWARDS="RECEIVE_CREW_AWARDS",i=(t.getCompetitionAwards=function(e){return function(t){fetch("/api/competitions/"+e+"/awards").then((function(e){return e.json()})).then((function(e){return t(i(e))}))}},t.getCrewAwards=function(e){return function(t){fetch("/api/crews/"+e+"/awards").then((function(e){return e.json()})).then((function(n){return t(a(n,e))}))}},function(e){return{type:r,awards:e}}),a=function(e,t){return{type:o,awards:e,crewId:t}}},412:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r="function"==typeof Symbol&&"symbol"==typeof Symbol.iterator?function(e){return typeof e}:function(e){return e&&"function"==typeof Symbol&&e.constructor===Symbol&&e!==Symbol.prototype?"symbol":typeof e};function o(e,t){return e===t}function i(e,t,n){if(null===t||null===n||t.length!==n.length)return!1;for(var r=t.length,o=0;o<r;o++)if(!e(t[o],n[o]))return!1;return!0}function a(e){var t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:o,n=null,r=null;return function(){return i(t,n,arguments)||(r=e.apply(null,arguments)),n=arguments,r}}function c(e){var t=Array.isArray(e[0])?e[0]:e;if(!t.every((function(e){return"function"==typeof e}))){var n=t.map((function(e){return void 0===e?"undefined":r(e)})).join(", ");throw new Error("Selector creators expect all input-selectors to be functions, instead received the following types: ["+n+"]")}return t}function s(e){for(var t=arguments.length,n=Array(t>1?t-1:0),r=1;r<t;r++)n[r-1]=arguments[r];return function(){for(var t=arguments.length,r=Array(t),o=0;o<t;o++)r[o]=arguments[o];var i=0,a=r.pop(),s=c(r),u=e.apply(void 0,[function(){return i++,a.apply(null,arguments)}].concat(n)),l=e((function(){for(var e=[],t=s.length,n=0;n<t;n++)e.push(s[n].apply(null,arguments));return u.apply(null,e)}));return l.resultFunc=a,l.dependencies=s,l.recomputations=function(){return i},l.resetRecomputations=function(){return i=0},l}}t.defaultMemoize=a,t.createSelectorCreator=s,t.createStructuredSelector=function(e){var t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:u;if("object"!==(void 0===e?"undefined":r(e)))throw new Error("createStructuredSelector expects first argument to be an object where each property is a selector, instead received a "+(void 0===e?"undefined":r(e)));var n=Object.keys(e);return t(n.map((function(t){return e[t]})),(function(){for(var e=arguments.length,t=Array(e),r=0;r<e;r++)t[r]=arguments[r];return t.reduce((function(e,t,r){return e[n[r]]=t,e}),{})}))};var u=t.createSelector=s(a)},413:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_CREWS="RECEIVE_CREWS",o=t.RECEIVE_CREW="RECEIVE_CREW",i=(t.getCompetitionCrews=function(e,t,n){return function(r){var o=t>0?"award="+t:"";n&&(""!=o&&(o+="&"),o+="s="+n),fetch("/api/competitions/"+e+"/crews"+(""!=o?"?"+o:"")).then((function(e){return e.json()})).then((function(e){return r(a(e))}))}},t.getCrew=function(e){return function(t){fetch("/api/crews/"+e).then((function(e){return e.json()})).then((function(e){return t(i(e))}))}},function(e){return{type:o,crew:e}}),a=function(e){return{type:r,crews:e}}},414:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_PENALTIES="RECEIVE_PENALTIES",o=(t.getCrewPenalties=function(e){return function(t){fetch("/api/crews/"+e+"/penalties").then((function(e){return e.json()})).then((function(n){return t(o(n,e))}))}},function(e,t){return{type:r,penalties:e,crewId:t}})},415:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.CardTableStyles=void 0;var r,o,i=(r=["\n<style>\ntable {\n    border-spacing: 0;\n    border-collapse: collapse;\n    width: 100%;\n}\n\ntr, td {\n    border-bottom: 1px rgba(0, 0, 0, 0.12) solid;\n}\n\ntr {\n    height: 48px;\n}\n\ntd, th {\n    text-align: left;\n    padding-left: 56px;\n    white-space: nowrap;\n}\n\ntd:first-child, th:first-child {\n    padding-left: 24px;\n}\n\ntd:last-child, th:last-child {\n    padding-right: 24px;\n}\n</style>\n"],o=["\n<style>\ntable {\n    border-spacing: 0;\n    border-collapse: collapse;\n    width: 100%;\n}\n\ntr, td {\n    border-bottom: 1px rgba(0, 0, 0, 0.12) solid;\n}\n\ntr {\n    height: 48px;\n}\n\ntd, th {\n    text-align: left;\n    padding-left: 56px;\n    white-space: nowrap;\n}\n\ntd:first-child, th:first-child {\n    padding-left: 24px;\n}\n\ntd:last-child, th:last-child {\n    padding-right: 24px;\n}\n</style>\n"],Object.freeze(Object.defineProperties(r,{raw:{value:Object.freeze(o)}}))),a=n(164);t.CardTableStyles=(0,a.html)(i)},416:function(e,t,n){"use strict";var r,o,i=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),a=(r=['\n            <link rel="stylesheet" href="/dist/site.css">\n            <style>\n            .mdc-card {\n                margin: 16px;\n            }\n            .headline {\n                padding: 1rem;\n            }\n            </style>\n            <div class="mdc-card">\n                <div class="mdc-typography--headline6 headline">','</div>\n                <slot name="content"></slot>\n            </div>\n        '],o=['\n            <link rel="stylesheet" href="/dist/site.css">\n            <style>\n            .mdc-card {\n                margin: 16px;\n            }\n            .headline {\n                padding: 1rem;\n            }\n            </style>\n            <div class="mdc-card">\n                <div class="mdc-typography--headline6 headline">','</div>\n                <slot name="content"></slot>\n            </div>\n        '],Object.freeze(Object.defineProperties(r,{raw:{value:Object.freeze(o)}}))),c=n(164);function s(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function u(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}var l=function(e){function t(){return s(this,t),u(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,e),i(t,[{key:"render",value:function(){return(0,c.html)(a,this.headline)}}],[{key:"properties",get:function(){return{headline:{type:String}}}}]),t}(c.LitElement);customElements.define("basic-card",l)},417:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.crewsListSelector=t.crewsSelector=void 0;var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(413),i=n(411),a=n(412),c=n(414);function s(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}var u={crews:{},orderedCrews:[]};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:u,t=arguments[1];switch(t.type){case o.RECEIVE_CREWS:return r({},e,{crews:t.crews.reduce((function(t,n){return t[n.id]=n,e.crews[n.id]&&(t[n.id].awards=e.crews[n.id].awards),t}),{}),orderedCrews:t.crews.map((function(e){return e.id}))});case o.RECEIVE_CREW:return r({},e,{crews:s({},t.crew.id,t.crew)});case i.RECEIVE_CREW_AWARDS:var n=r({},e.crews[t.crewId],{awards:t.awards.map((function(e){return e.id}))});return r({},e,{crews:Object.keys(e.crews).reduce((function(o,i){return o[i]=t.crewId!==i?e.crews[i]:r({},e.crews[i],n),o}),{})});case c.RECEIVE_PENALTIES:return n=r({},e.crews[t.crewId],{penalties:t.penalties.map((function(e){return e.id}))}),r({},e,{crews:Object.keys(e.crews).reduce((function(o,i){return o[i]=t.crewId!==i?e.crews[i]:r({},e.crews[i],n),o}),{})});default:return e}};var l=t.crewsSelector=function(e){return e.crews&&e.crews.crews};t.crewsListSelector=(0,a.createSelector)(l,(function(e){return e.crews&&e.crews.orderedCrews}),(function(e,t){if(e)return t.map((function(t){return e[t]}))}))},422:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.awardsListSelector=t.awardsSelector=void 0;var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(411),i=n(412),a={awards:{},orderedAwards:[]};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:a,t=arguments[1];switch(t.type){case o.RECEIVE_AWARDS:return r({},e,{awards:t.awards.reduce((function(e,t){return e[t.id]=t,e}),e.awards),orderedAwards:t.awards.map((function(e){return e.id}))});case o.RECEIVE_CREW_AWARDS:return r({},e,{awards:t.awards.reduce((function(e,t){return e[t.id]=t,e}),e.awards)});default:return e}};var c=t.awardsSelector=function(e){return e.awards&&e.awards.awards};t.awardsListSelector=(0,i.createSelector)(c,(function(e){return e.awards&&e.awards.orderedAwards}),(function(e,t){if(e)return t.map((function(t){return e[t]}))}))},428:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_ATHLETES="RECEIVE_ATHLETES",o=(t.getCrewAthletes=function(e){return function(t){fetch("/api/crews/"+e+"/athletes").then((function(e){return e.json()})).then((function(n){return t(o(n,e))}))}},function(e,t){return{type:r,athletes:e,crewId:t}})},429:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_RESULTS="RECEIVE_RESULTS",o=(t.getCrewResults=function(e){return function(t){fetch("/api/crews/"+e+"/results").then((function(e){return e.json()})).then((function(e){return t(o(e))}))}},function(e){return{type:r,results:e}})},441:function(e,t,n){"use strict";var r,o=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),i=b(["\n        ",'\n        <basic-card headline="Section Times">\n            <table slot="content">\n            <tr><th>Point</th><th>Time of Day</th><th>Section Time</th><th>Total Time</th></tr>\n            ',"\n        </table>\n        </basic-card>\n        "],["\n        ",'\n        <basic-card headline="Section Times">\n            <table slot="content">\n            <tr><th>Point</th><th>Time of Day</th><th>Section Time</th><th>Total Time</th></tr>\n            ',"\n        </table>\n        </basic-card>\n        "]),a=b(["\n                <tr>\n                    <td>","</td>\n                    <td>","</td>\n                    <td>","</td>\n                    <td>","</td>\n                </tr>\n           "],["\n                <tr>\n                    <td>","</td>\n                    <td>","</td>\n                    <td>","</td>\n                    <td>","</td>\n                </tr>\n           "]),c=b([""," (",")"],[""," (",")"]),s=n(164),u=n(165),l=n(166),d=n(409),f=n(415),p=n(442),h=(r=p)&&r.__esModule?r:{default:r};n(416);var w=n(429);function b(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}function y(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function v(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}l.store.addReducers({results:h.default});var m=function(e){function t(){return y(this,t),v(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,e),o(t,[{key:"render",value:function(){return(0,s.html)(i,f.CardTableStyles,this._results&&(0,d.repeat)(this._results,(function(e){return(0,s.html)(a,e.name,e.timeOfDay,e.sectionTime,e.runTime?(0,s.html)(c,e.runTime,e.rank):null)})))}},{key:"firstUpdated",value:function(){l.store.dispatch((0,w.getCrewResults)(this.crewId))}},{key:"stateChanged",value:function(e){this._results=Object.values(e.results.results)}}],[{key:"properties",get:function(){return{crewId:{type:Number},_results:{type:Array}}}}]),t}((0,u.connect)(l.store)(s.LitElement));window.customElements.define("results-card",m)},442:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(429),i={results:{},resultsForCrew:{}};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:i,t=arguments[1];switch(t.type){case o.RECEIVE_RESULTS:return r({},e,{results:t.results});default:return e}}},443:function(e,t,n){"use strict";var r,o=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),i=h(["\n        ",'\n        <basic-card headline="Penalties">\n            <table slot="content">\n                <thead>\n                    <tr><th>Amount</th><th>Reason</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n        "],["\n        ",'\n        <basic-card headline="Penalties">\n            <table slot="content">\n                <thead>\n                    <tr><th>Amount</th><th>Reason</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n        "]),a=h(["\n                    <tr><td>","</td><td>","</td></tr>\n                    "],["\n                    <tr><td>","</td><td>","</td></tr>\n                    "]),c=n(164),s=n(165),u=n(166),l=n(415),d=n(409),f=n(444),p=(r=f)&&r.__esModule?r:{default:r};function h(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}function w(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function b(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}n(416),u.store.addReducers({penalties:p.default});var y=function(e){function t(){return w(this,t),b(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,e),o(t,[{key:"render",value:function(){return(0,c.html)(i,l.CardTableStyles,this._penalties&&(0,d.repeat)(this._penalties,(function(e){return(0,c.html)(a,e.value,e.reason)})))}},{key:"stateChanged",value:function(e){var t=e.crews.crews[this.crewId];t&&t.penalties&&(this._penalties=t.penalties.map((function(t){return e.penalties.byId[t]})))}}],[{key:"properties",get:function(){return{crewId:{type:Number},_penalties:{type:Array}}}}]),t}((0,s.connect)(u.store)(c.LitElement));window.customElements.define("penalties-card",y)},444:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(414),i={byId:{}};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:i,t=arguments[1];switch(t.type){case o.RECEIVE_PENALTIES:return r({},e,{byId:t.penalties.reduce((function(e,t){return e[t.id]=t,e}),e.byId)});default:return e}}},445:function(e,t,n){"use strict";var r,o=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),i=h(["\n        ",'\n        <basic-card headline="Awards">\n            <table slot="content">\n                <thead>\n                    <tr><th>Title</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n        "],["\n        ",'\n        <basic-card headline="Awards">\n            <table slot="content">\n                <thead>\n                    <tr><th>Title</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n        "]),a=h(["\n                    <tr><td>","</td></tr>\n                    "],["\n                    <tr><td>","</td></tr>\n                    "]),c=n(164),s=n(165),u=n(166),l=n(415),d=n(409),f=n(422),p=(r=f)&&r.__esModule?r:{default:r};n(416);n(411);function h(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}function w(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function b(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}u.store.addReducers({awards:p.default});var y=function(e){function t(){return w(this,t),b(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,e),o(t,[{key:"render",value:function(){return(0,c.html)(i,l.CardTableStyles,this._awards&&(0,d.repeat)(this._awards,(function(e){return(0,c.html)(a,e.title)})))}},{key:"stateChanged",value:function(e){var t=e.crews.crews[this.crewId];t&&t.awards&&(this._awards=t.awards.map((function(t){return e.awards.awards[t]})))}}],[{key:"properties",get:function(){return{crewId:{type:Number},_awards:{type:Array}}}}]),t}((0,s.connect)(u.store)(c.LitElement));window.customElements.define("awards-card",y)},446:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(428);var i={athletes:{},athletesByCrew:{}},a=function(e,t){switch(t.type){case o.RECEIVE_ATHLETES:var n=t.crewId;return r({},e,(i={},a=n,c=t.athletes.map((function(e){return e.id})),a in i?Object.defineProperty(i,a,{value:c,enumerable:!0,configurable:!0,writable:!0}):i[a]=c,i));default:return e}var i,a,c};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:i,t=arguments[1];switch(t.type){case o.RECEIVE_ATHLETES:return r({},e,{athletes:t.athletes.reduce((function(e,t){return e[t.id]=t,e}),{}),athletesByCrew:a(e.athletesByCrew,t)});default:return e}}}}]);