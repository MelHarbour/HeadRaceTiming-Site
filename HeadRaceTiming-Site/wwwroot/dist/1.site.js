(window.webpackJsonp=window.webpackJsonp||[]).push([[1],{382:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.getCrewPenalties=t.getCrewAwards=t.getCrewAthletes=void 0;var r=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),o=_(['\n        <link rel="stylesheet" href="/dist/site.css">\n        ','\n\n        <basic-card headline="Crew Details">\n        <div slot="content" style="padding: 1rem">\n            <div>',"</div>\n            <div>Competition: <a href=",">","</a></div>\n            <div>Start Number: ","</div>\n            <div>CRI Max: ",'</div>\n        </div>\n        </basic-card>\n\n        <basic-card headline="Athletes">\n            <table slot="content">\n                <thead>\n                    <tr><th>Seat</th><th>Name</th><th>PRI</th><th>PRIMax</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n\n        <results-card crewId=","></results-card>\n\n        <penalties-card crewId=","></penalties-card>\n\n        <awards-card crewId=","></awards-card>\n       "],['\n        <link rel="stylesheet" href="/dist/site.css">\n        ','\n\n        <basic-card headline="Crew Details">\n        <div slot="content" style="padding: 1rem">\n            <div>',"</div>\n            <div>Competition: <a href=",">","</a></div>\n            <div>Start Number: ","</div>\n            <div>CRI Max: ",'</div>\n        </div>\n        </basic-card>\n\n        <basic-card headline="Athletes">\n            <table slot="content">\n                <thead>\n                    <tr><th>Seat</th><th>Name</th><th>PRI</th><th>PRIMax</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n\n        <results-card crewId=","></results-card>\n\n        <penalties-card crewId=","></penalties-card>\n\n        <awards-card crewId=","></awards-card>\n       "]),i=_(["\n                        <tr>\n                            <td>","</td>\n                            <td>"," ","</td>\n                            <td>","</td>\n                            <td>","</td>\n                        </tr>\n                    "],["\n                        <tr>\n                            <td>","</td>\n                            <td>"," ","</td>\n                            <td>","</td>\n                            <td>","</td>\n                        </tr>\n                    "]),a=n(144),c=n(385),s=n(145),u=n(146),l=n(391),d=v(l),f=n(394),p=n(386),h=n(387),y=n(384),b=n(389);n(390),n(401),n(403),n(405);var w=v(n(406));function v(e){return e&&e.__esModule?e:{default:e}}function _(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}u.store.addReducers({crews:d.default,athletes:w.default});var m=function(e){function t(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,(0,s.connect)(u.store)(c.PageViewElement)),r(t,[{key:"render",value:function(){var e=this;return(0,a.html)(o,b.CardTableStyles,this._crew.name,this._compLink,this._competitionName,this._crew.startNumber,this._crew.criMax,this._athletes&&(0,y.repeat)(this._athletes,function(t){return(0,a.html)(i,e._positionText(t.position),t.firstName,t.lastName,t.pri,t.priMax)}),this._crew.id,this._crew.id,this._crew.id)}},{key:"_positionText",value:function(e){switch(this._crew.boatClass){case 7:switch(e){case 1:return"Bow";case 8:return"Stroke";case 9:return"Cox";default:return e}default:return e}}},{key:"stateChanged",value:function(e){if(e.app.focussedCrew&&(0,l.crewsSelector)(e)[e.app.focussedCrew]&&(this._crew=(0,l.crewsSelector)(e)[e.app.focussedCrew],this._athletes=Object.values(e.athletes.athletes)),e.app.focussedCompetition){this._compLink="/results/"+e.app.focussedCompetition;var t=e.competitions.competitionsByFriendlyName[e.app.focussedCompetition];this._competitionName=e.competitions.competitions[t].name}}}],[{key:"properties",get:function(){return{_crew:{type:Object},_competitionName:{type:String},_compLink:{type:String},_athletes:{type:Array}}}}]),t}();window.customElements.define("crew-view",m),t.getCrewAthletes=f.getCrewAthletes,t.getCrewAwards=p.getCrewAwards,t.getCrewPenalties=h.getCrewPenalties},384:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.repeat=void 0;var r=n(70),o=function(e,t){var n=e.startNode.parentNode,o=void 0===t?e.endNode:t.startNode,i=n.insertBefore((0,r.createMarker)(),o);n.insertBefore((0,r.createMarker)(),o);var a=new r.NodePart(e.options);return a.insertAfterNode(i),a},i=function(e,t){return e.setValue(t),e.commit(),e},a=function(e,t,n){var o=e.startNode.parentNode,i=n?n.startNode:e.endNode,a=t.endNode.nextSibling;a!==i&&(0,r.reparentNodes)(o,t.startNode,a,i)},c=function(e){(0,r.removeNodes)(e.startNode.parentNode,e.startNode,e.endNode.nextSibling)},s=function(e,t,n){for(var r=new Map,o=t;o<=n;o++)r.set(e[o],o);return r},u=new WeakMap,l=new WeakMap;t.repeat=(0,r.directive)(function(e,t,n){var d=void 0;return void 0===n?n=t:void 0!==t&&(d=t),function(t){if(!(t instanceof r.NodePart))throw new Error("repeat can only be used in text bindings");var f=u.get(t)||[],p=l.get(t)||[],h=[],y=[],b=[],w=0,v=!0,_=!1,m=void 0;try{for(var E,g=e[Symbol.iterator]();!(v=(E=g.next()).done);v=!0){var O=E.value;b[w]=d?d(O,w):w,y[w]=n(O,w),w++}}catch(e){_=!0,m=e}finally{try{!v&&g.return&&g.return()}finally{if(_)throw m}}for(var j=void 0,C=void 0,P=0,S=f.length-1,R=0,I=y.length-1;P<=S&&R<=I;)if(null===f[P])P++;else if(null===f[S])S--;else if(p[P]===b[R])h[R]=i(f[P],y[R]),P++,R++;else if(p[S]===b[I])h[I]=i(f[S],y[I]),S--,I--;else if(p[P]===b[I])h[I]=i(f[P],y[I]),a(t,f[P],h[I+1]),P++,I--;else if(p[S]===b[R])h[R]=i(f[S],y[R]),a(t,f[S],f[P]),S--,R++;else if(void 0===j&&(j=s(b,R,I),C=s(p,P,S)),j.has(p[P]))if(j.has(p[S])){var T=C.get(b[R]),A=void 0!==T?f[T]:null;if(null===A){var k=o(t,f[P]);i(k,y[R]),h[R]=k}else h[R]=i(A,y[R]),a(t,A,f[P]),f[T]=null;R++}else c(f[S]),S--;else c(f[P]),P++;for(;R<=I;){var N=o(t,h[I+1]);i(N,y[R]),h[R++]=N}for(;P<=S;){var x=f[P++];null!==x&&c(x)}u.set(t,h),l.set(t,b)}})},385:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.PageViewElement=void 0;var r=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),o=n(144);t.PageViewElement=function(e){function t(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,o.LitElement),r(t,[{key:"shouldUpdate",value:function(){return this.active}}],[{key:"properties",get:function(){return{active:{type:Boolean}}}}]),t}()},386:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_AWARDS="RECEIVE_AWARDS",o=t.RECEIVE_CREW_AWARDS="RECEIVE_CREW_AWARDS",i=(t.getCompetitionAwards=function(e){return function(t){fetch("/api/competitions/"+e+"/awards").then(function(e){return e.json()}).then(function(e){return t(i(e))})}},t.getCrewAwards=function(e){return function(t){fetch("/api/crews/"+e+"/awards").then(function(e){return e.json()}).then(function(n){return t(a(n,e))})}},function(e){return{type:r,awards:e}}),a=function(e,t){return{type:o,awards:e,crewId:t}}},387:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_PENALTIES="RECEIVE_PENALTIES",o=(t.getCrewPenalties=function(e){return function(t){fetch("/api/crews/"+e+"/penalties").then(function(e){return e.json()}).then(function(n){return t(o(n,e))})}},function(e,t){return{type:r,penalties:e,crewId:t}})},388:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_CREWS="RECEIVE_CREWS",o=(t.getCompetitionCrews=function(e,t){return function(n){fetch("/api/competitions/"+e+"/crews"+(t>0?"?award="+t:"")).then(function(e){return e.json()}).then(function(e){return n(o(e))})}},function(e){return{type:r,crews:e}})},389:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.CardTableStyles=void 0;var r,o,i=(r=["\n<style>\ntable {\n    border-spacing: 0;\n    border-collapse: collapse;\n    width: 100%;\n}\n\ntr, td {\n    border-bottom: 1px rgba(0, 0, 0, 0.12) solid;\n}\n\ntr {\n    height: 48px;\n}\n\ntd, th {\n    text-align: left;\n    padding-left: 56px;\n    white-space: nowrap;\n}\n\ntd:first-child, th:first-child {\n    padding-left: 24px;\n}\n\ntd:last-child, th:last-child {\n    padding-right: 24px;\n}\n</style>\n"],o=["\n<style>\ntable {\n    border-spacing: 0;\n    border-collapse: collapse;\n    width: 100%;\n}\n\ntr, td {\n    border-bottom: 1px rgba(0, 0, 0, 0.12) solid;\n}\n\ntr {\n    height: 48px;\n}\n\ntd, th {\n    text-align: left;\n    padding-left: 56px;\n    white-space: nowrap;\n}\n\ntd:first-child, th:first-child {\n    padding-left: 24px;\n}\n\ntd:last-child, th:last-child {\n    padding-right: 24px;\n}\n</style>\n"],Object.freeze(Object.defineProperties(r,{raw:{value:Object.freeze(o)}}))),a=n(144);t.CardTableStyles=(0,a.html)(i)},390:function(e,t,n){"use strict";var r,o,i=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),a=(r=['\n            <link rel="stylesheet" href="/dist/site.css">\n            <style>\n            .mdc-card {\n                margin: 16px;\n            }\n            .headline {\n                padding: 1rem;\n            }\n            </style>\n            <div class="mdc-card">\n                <div class="mdc-typography--headline6 headline">','</div>\n                <slot name="content"></slot>\n            </div>\n        '],o=['\n            <link rel="stylesheet" href="/dist/site.css">\n            <style>\n            .mdc-card {\n                margin: 16px;\n            }\n            .headline {\n                padding: 1rem;\n            }\n            </style>\n            <div class="mdc-card">\n                <div class="mdc-typography--headline6 headline">','</div>\n                <slot name="content"></slot>\n            </div>\n        '],Object.freeze(Object.defineProperties(r,{raw:{value:Object.freeze(o)}}))),c=n(144);var s=function(e){function t(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,c.LitElement),i(t,[{key:"render",value:function(){return(0,c.html)(a,this.headline)}}],[{key:"properties",get:function(){return{headline:{type:String}}}}]),t}();customElements.define("basic-card",s)},391:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.crewsListSelector=t.crewsSelector=void 0;var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(388),i=n(386),a=n(392),c=n(387),s={crews:{},orderedCrews:[]};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:s,t=arguments[1];switch(t.type){case o.RECEIVE_CREWS:return r({},e,{crews:t.crews.reduce(function(t,n){return t[n.id]=n,e.crews[n.id]&&(t[n.id].awards=e.crews[n.id].awards),t},{}),orderedCrews:t.crews.map(function(e){return e.id})});case i.RECEIVE_CREW_AWARDS:var n=r({},e.crews[t.crewId],{awards:t.awards.map(function(e){return e.id})});return r({},e,{crews:Object.keys(e.crews).reduce(function(o,i){return o[i]=t.crewId!==i?e.crews[i]:r({},e.crews[i],n),o},{})});case c.RECEIVE_PENALTIES:return n=r({},e.crews[t.crewId],{penalties:t.penalties.map(function(e){return e.id})}),r({},e,{crews:Object.keys(e.crews).reduce(function(o,i){return o[i]=t.crewId!==i?e.crews[i]:r({},e.crews[i],n),o},{})});default:return e}};var u=t.crewsSelector=function(e){return e.crews&&e.crews.crews};t.crewsListSelector=(0,a.createSelector)(u,function(e){return e.crews&&e.crews.orderedCrews},function(e,t){if(e)return t.map(function(t){return e[t]})})},392:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r="function"==typeof Symbol&&"symbol"==typeof Symbol.iterator?function(e){return typeof e}:function(e){return e&&"function"==typeof Symbol&&e.constructor===Symbol&&e!==Symbol.prototype?"symbol":typeof e};function o(e,t){return e===t}function i(e){var t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:o,n=null,r=null;return function(){return function(e,t,n){if(null===t||null===n||t.length!==n.length)return!1;for(var r=t.length,o=0;o<r;o++)if(!e(t[o],n[o]))return!1;return!0}(t,n,arguments)||(r=e.apply(null,arguments)),n=arguments,r}}function a(e){for(var t=arguments.length,n=Array(t>1?t-1:0),o=1;o<t;o++)n[o-1]=arguments[o];return function(){for(var t=arguments.length,o=Array(t),i=0;i<t;i++)o[i]=arguments[i];var a=0,c=o.pop(),s=function(e){var t=Array.isArray(e[0])?e[0]:e;if(!t.every(function(e){return"function"==typeof e})){var n=t.map(function(e){return void 0===e?"undefined":r(e)}).join(", ");throw new Error("Selector creators expect all input-selectors to be functions, instead received the following types: ["+n+"]")}return t}(o),u=e.apply(void 0,[function(){return a++,c.apply(null,arguments)}].concat(n)),l=e(function(){for(var e=[],t=s.length,n=0;n<t;n++)e.push(s[n].apply(null,arguments));return u.apply(null,e)});return l.resultFunc=c,l.dependencies=s,l.recomputations=function(){return a},l.resetRecomputations=function(){return a=0},l}}t.defaultMemoize=i,t.createSelectorCreator=a,t.createStructuredSelector=function(e){var t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:c;if("object"!==(void 0===e?"undefined":r(e)))throw new Error("createStructuredSelector expects first argument to be an object where each property is a selector, instead received a "+(void 0===e?"undefined":r(e)));var n=Object.keys(e);return t(n.map(function(t){return e[t]}),function(){for(var e=arguments.length,t=Array(e),r=0;r<e;r++)t[r]=arguments[r];return t.reduce(function(e,t,r){return e[n[r]]=t,e},{})})};var c=t.createSelector=a(i)},393:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(386),i={awards:{}};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:i,t=arguments[1];switch(t.type){case o.RECEIVE_AWARDS:case o.RECEIVE_CREW_AWARDS:return r({},e,{awards:t.awards.reduce(function(e,t){return e[t.id]=t,e},e.awards)});default:return e}}},394:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_ATHLETES="RECEIVE_ATHLETES",o=(t.getCrewAthletes=function(e){return function(t){fetch("/api/crews/"+e+"/athletes").then(function(e){return e.json()}).then(function(e){return t(o(e))})}},function(e){return{type:r,athletes:e}})},395:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_RESULTS="RECEIVE_RESULTS",o=(t.getCrewResults=function(e){return function(t){fetch("/api/crews/"+e+"/results").then(function(e){return e.json()}).then(function(e){return t(o(e))})}},function(e){return{type:r,results:e}})},401:function(e,t,n){"use strict";var r,o=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),i=b(["\n        ",'\n        <basic-card headline="Section Times">\n            <table slot="content">\n            <tr><th>Point</th><th>Time of Day</th><th>Section Time</th><th>Total Time</th></tr>\n            ',"\n        </table>\n        </basic-card>\n        "],["\n        ",'\n        <basic-card headline="Section Times">\n            <table slot="content">\n            <tr><th>Point</th><th>Time of Day</th><th>Section Time</th><th>Total Time</th></tr>\n            ',"\n        </table>\n        </basic-card>\n        "]),a=b(["\n                <tr>\n                    <td>","</td>\n                    <td>","</td>\n                    <td>","</td>\n                    <td>","</td>\n                </tr>\n           "],["\n                <tr>\n                    <td>","</td>\n                    <td>","</td>\n                    <td>","</td>\n                    <td>","</td>\n                </tr>\n           "]),c=b([""," (",")"],[""," (",")"]),s=n(144),u=n(145),l=n(146),d=n(384),f=n(389),p=n(402),h=(r=p)&&r.__esModule?r:{default:r};n(390);var y=n(395);function b(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}l.store.addReducers({results:h.default});var w=function(e){function t(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,(0,u.connect)(l.store)(s.LitElement)),o(t,[{key:"render",value:function(){return(0,s.html)(i,f.CardTableStyles,this._results&&(0,d.repeat)(this._results,function(e){return(0,s.html)(a,e.name,e.timeOfDay,e.sectionTime,e.runTime?(0,s.html)(c,e.runTime,e.rank):null)}))}},{key:"firstUpdated",value:function(){l.store.dispatch((0,y.getCrewResults)(this.crewId))}},{key:"stateChanged",value:function(e){this._results=Object.values(e.results.results)}}],[{key:"properties",get:function(){return{crewId:{type:Number},_results:{type:Array}}}}]),t}();window.customElements.define("results-card",w)},402:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(395),i={results:{},resultsForCrew:{}};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:i,t=arguments[1];switch(t.type){case o.RECEIVE_RESULTS:return r({},e,{results:t.results});default:return e}}},403:function(e,t,n){"use strict";var r,o=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),i=h(["\n        ",'\n        <basic-card headline="Penalties">\n            <table slot="content">\n                <thead>\n                    <tr><th>Amount</th><th>Reason</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n        "],["\n        ",'\n        <basic-card headline="Penalties">\n            <table slot="content">\n                <thead>\n                    <tr><th>Amount</th><th>Reason</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n        "]),a=h(["\n                    <tr><td>","</td><td>","</td></tr>\n                    "],["\n                    <tr><td>","</td><td>","</td></tr>\n                    "]),c=n(144),s=n(145),u=n(146),l=n(389),d=n(384),f=n(404),p=(r=f)&&r.__esModule?r:{default:r};function h(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}n(390),u.store.addReducers({penalties:p.default});var y=function(e){function t(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,(0,s.connect)(u.store)(c.LitElement)),o(t,[{key:"render",value:function(){return(0,c.html)(i,l.CardTableStyles,this._penalties&&(0,d.repeat)(this._penalties,function(e){return(0,c.html)(a,e.value,e.reason)}))}},{key:"stateChanged",value:function(e){var t=e.crews.crews[this.crewId];t&&t.penalties&&(this._penalties=t.penalties.map(function(t){return e.penalties.byId[t]}))}}],[{key:"properties",get:function(){return{crewId:{type:Number},_penalties:{type:Array}}}}]),t}();window.customElements.define("penalties-card",y)},404:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(387),i={byId:{}};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:i,t=arguments[1];switch(t.type){case o.RECEIVE_PENALTIES:return r({},e,{byId:t.penalties.reduce(function(e,t){return e[t.id]=t,e},e.byId)});default:return e}}},405:function(e,t,n){"use strict";var r,o=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),i=h(["\n        ",'\n        <basic-card headline="Awards">\n            <table slot="content">\n                <thead>\n                    <tr><th>Title</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n        "],["\n        ",'\n        <basic-card headline="Awards">\n            <table slot="content">\n                <thead>\n                    <tr><th>Title</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n        "]),a=h(["\n                    <tr><td>","</td></tr>\n                    "],["\n                    <tr><td>","</td></tr>\n                    "]),c=n(144),s=n(145),u=n(146),l=n(389),d=n(384),f=n(393),p=(r=f)&&r.__esModule?r:{default:r};n(390);n(386);function h(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}u.store.addReducers({awards:p.default});var y=function(e){function t(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,(0,s.connect)(u.store)(c.LitElement)),o(t,[{key:"render",value:function(){return(0,c.html)(i,l.CardTableStyles,this._awards&&(0,d.repeat)(this._awards,function(e){return(0,c.html)(a,e.title)}))}},{key:"stateChanged",value:function(e){var t=e.crews.crews[this.crewId];t&&t.awards&&(this._awards=t.awards.map(function(t){return e.awards.awards[t]}))}}],[{key:"properties",get:function(){return{crewId:{type:Number},_awards:{type:Array}}}}]),t}();window.customElements.define("awards-card",y)},406:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(394),i={athletes:{},athletesByCrew:{}};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:i,t=arguments[1];switch(t.type){case o.RECEIVE_ATHLETES:return r({},e,{athletes:t.athletes});default:return e}}}}]);