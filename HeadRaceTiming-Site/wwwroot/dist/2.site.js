(window.webpackJsonp=window.webpackJsonp||[]).push([[2],{106:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.repeat=void 0;var r=n(70),i=function(e,t){var n=e.startNode.parentNode,i=void 0===t?e.endNode:t.startNode,o=n.insertBefore((0,r.createMarker)(),i);n.insertBefore((0,r.createMarker)(),i);var a=new r.NodePart(e.options);return a.insertAfterNode(o),a},o=function(e,t){return e.setValue(t),e.commit(),e},a=function(e,t,n){var i=e.startNode.parentNode,o=n?n.startNode:e.endNode,a=t.endNode.nextSibling;a!==o&&(0,r.reparentNodes)(i,t.startNode,a,o)},c=function(e){(0,r.removeNodes)(e.startNode.parentNode,e.startNode,e.endNode.nextSibling)},d=function(e,t,n){for(var r=new Map,i=t;i<=n;i++)r.set(e[i],i);return r},s=new WeakMap,l=new WeakMap;t.repeat=(0,r.directive)(function(e,t,n){var u=void 0;return void 0===n?n=t:void 0!==t&&(u=t),function(t){if(!(t instanceof r.NodePart))throw new Error("repeat can only be used in text bindings");var p=s.get(t)||[],f=l.get(t)||[],h=[],v=[],y=[],m=0,b=!0,w=!1,g=void 0;try{for(var _,E=e[Symbol.iterator]();!(b=(_=E.next()).done);b=!0){var S=_.value;y[m]=u?u(S,m):m,v[m]=n(S,m),m++}}catch(e){w=!0,g=e}finally{try{!b&&E.return&&E.return()}finally{if(w)throw g}}for(var C=void 0,N=void 0,j=0,x=p.length-1,O=0,P=v.length-1;j<=x&&O<=P;)if(null===p[j])j++;else if(null===p[x])x--;else if(f[j]===y[O])h[O]=o(p[j],v[O]),j++,O++;else if(f[x]===y[P])h[P]=o(p[x],v[P]),x--,P--;else if(f[j]===y[P])h[P]=o(p[j],v[P]),a(t,p[j],h[P+1]),j++,P--;else if(f[x]===y[O])h[O]=o(p[x],v[O]),a(t,p[x],p[j]),x--,O++;else if(void 0===C&&(C=d(y,O,P),N=d(f,j,x)),C.has(f[j]))if(C.has(f[x])){var M=N.get(y[O]),R=void 0!==M?p[M]:null;if(null===R){var A=i(t,p[j]);o(A,v[O]),h[O]=A}else h[O]=o(R,v[O]),a(t,R,p[j]),p[M]=null;O++}else c(p[x]),x--;else c(p[j]),j++;for(;O<=P;){var k=i(t,h[P+1]);o(k,v[O]),h[O++]=k}for(;j<=x;){var I=p[j++];null!==I&&c(I)}s.set(t,h),l.set(t,y)}})},149:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.crewsListSelector=t.crewsSelector=void 0;var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},i=n(150),o=n(379),a={crews:{},orderedCrews:[]};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:a,t=arguments[1];switch(t.type){case i.RECEIVE_CREWS:return r({},e,{crews:t.crews.reduce(function(e,t){return e[t.id]=t,e},{}),orderedCrews:t.crews.map(function(e){return e.id})});default:return e}};var c=t.crewsSelector=function(e){return e.crews&&e.crews.crews};t.crewsListSelector=(0,o.createSelector)(c,function(e){return e.crews&&e.crews.orderedCrews},function(e,t){if(e)return t.map(function(t){return e[t]})})},150:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_CREWS="RECEIVE_CREWS",i=(t.getCompetitionCrews=function(e){return function(t){fetch("/api/competitions/"+e+"/crews").then(function(e){return e.json()}).then(function(e){return t(i(e))})}},function(e){return{type:r,crews:e}})},151:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_ATHLETES="RECEIVE_ATHLETES",i=(t.getCrewAthletes=function(e){return function(t){fetch("/api/crews/"+e+"/athletes").then(function(e){return e.json()}).then(function(e){return t(i(e))})}},function(e){return{type:r,athletes:e}})},379:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r="function"==typeof Symbol&&"symbol"==typeof Symbol.iterator?function(e){return typeof e}:function(e){return e&&"function"==typeof Symbol&&e.constructor===Symbol&&e!==Symbol.prototype?"symbol":typeof e};function i(e,t){return e===t}function o(e){var t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:i,n=null,r=null;return function(){return function(e,t,n){if(null===t||null===n||t.length!==n.length)return!1;for(var r=t.length,i=0;i<r;i++)if(!e(t[i],n[i]))return!1;return!0}(t,n,arguments)||(r=e.apply(null,arguments)),n=arguments,r}}function a(e){for(var t=arguments.length,n=Array(t>1?t-1:0),i=1;i<t;i++)n[i-1]=arguments[i];return function(){for(var t=arguments.length,i=Array(t),o=0;o<t;o++)i[o]=arguments[o];var a=0,c=i.pop(),d=function(e){var t=Array.isArray(e[0])?e[0]:e;if(!t.every(function(e){return"function"==typeof e})){var n=t.map(function(e){return void 0===e?"undefined":r(e)}).join(", ");throw new Error("Selector creators expect all input-selectors to be functions, instead received the following types: ["+n+"]")}return t}(i),s=e.apply(void 0,[function(){return a++,c.apply(null,arguments)}].concat(n)),l=e(function(){for(var e=[],t=d.length,n=0;n<t;n++)e.push(d[n].apply(null,arguments));return s.apply(null,e)});return l.resultFunc=c,l.dependencies=d,l.recomputations=function(){return a},l.resetRecomputations=function(){return a=0},l}}t.defaultMemoize=o,t.createSelectorCreator=a,t.createStructuredSelector=function(e){var t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:c;if("object"!==(void 0===e?"undefined":r(e)))throw new Error("createStructuredSelector expects first argument to be an object where each property is a selector, instead received a "+(void 0===e?"undefined":r(e)));var n=Object.keys(e);return t(n.map(function(t){return e[t]}),function(){for(var e=arguments.length,t=Array(e),r=0;r<e;r++)t[r]=arguments[r];return t.reduce(function(e,t,r){return e[n[r]]=t,e},{})})};var c=t.createSelector=a(o)},383:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.getCrewAthletes=void 0;var r=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}(),i=m(['\n        <link rel="stylesheet" href="/dist/site.css">\n        <style>\n.mdc-card {\n    margin: 16px;\n}\ntable {\n    border-spacing: 0;\n    border-collapse: collapse;\n    width: 100%;\n}\n\ntr, td {\n    border-bottom: 1px rgba(0, 0, 0, 0.12) solid;\n}\n\ntr {\n    height: 48px;\n}\n\ntd, th {\n    text-align: left;\n    padding-left: 56px;\n    white-space: nowrap;\n}\n\ntd:first-child, th:first-child {\n    padding-left: 24px;\n}\n\ntd:last-child, th:last-child {\n    padding-right: 24px;\n}\n</style>\n\n        <div class="mdc-card">\n        <div class="mdc-card__primary-action">\n        <div class="mdc-typography--headline6">Crew Details</div>\n            <div>',"</div>\n            <div>Competition: <a href=",">","</a></div>\n            <div>Start Number: ","</div>\n            <div>CRI Max: ",'</div>\n        </div>\n        </div>\n\n        <div class="mdc-card">\n        <div class="mdc-card__primary-action">\n        <div class="mdc-typography--headline6">Athletes</div>\n            <table>\n                <thead>\n                    <tr><th>Seat</th><th>Name</th><th>PRI</th><th>PRIMax</th></tr>\n                </thead>\n                <tbody>\n                    ','\n                </tbody>\n            </table>\n        </div>\n        </div>\n\n        <div class="mdc-card">\n        <div class="mdc-card__primary-action">\n        <div class="mdc-typography--headline6">Penalties</div>\n            <table>\n                <thead>\n                    <tr><th>Amount</th><th>Reason</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </div>\n        </div>\n       "],['\n        <link rel="stylesheet" href="/dist/site.css">\n        <style>\n.mdc-card {\n    margin: 16px;\n}\ntable {\n    border-spacing: 0;\n    border-collapse: collapse;\n    width: 100%;\n}\n\ntr, td {\n    border-bottom: 1px rgba(0, 0, 0, 0.12) solid;\n}\n\ntr {\n    height: 48px;\n}\n\ntd, th {\n    text-align: left;\n    padding-left: 56px;\n    white-space: nowrap;\n}\n\ntd:first-child, th:first-child {\n    padding-left: 24px;\n}\n\ntd:last-child, th:last-child {\n    padding-right: 24px;\n}\n</style>\n\n        <div class="mdc-card">\n        <div class="mdc-card__primary-action">\n        <div class="mdc-typography--headline6">Crew Details</div>\n            <div>',"</div>\n            <div>Competition: <a href=",">","</a></div>\n            <div>Start Number: ","</div>\n            <div>CRI Max: ",'</div>\n        </div>\n        </div>\n\n        <div class="mdc-card">\n        <div class="mdc-card__primary-action">\n        <div class="mdc-typography--headline6">Athletes</div>\n            <table>\n                <thead>\n                    <tr><th>Seat</th><th>Name</th><th>PRI</th><th>PRIMax</th></tr>\n                </thead>\n                <tbody>\n                    ','\n                </tbody>\n            </table>\n        </div>\n        </div>\n\n        <div class="mdc-card">\n        <div class="mdc-card__primary-action">\n        <div class="mdc-typography--headline6">Penalties</div>\n            <table>\n                <thead>\n                    <tr><th>Amount</th><th>Reason</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </div>\n        </div>\n       "]),o=m(["\n                        <tr>\n                            <td>","</td>\n                            <td>"," ","</td>\n                            <td>","</td>\n                            <td>","</td>\n                        </tr>\n                    "],["\n                        <tr>\n                            <td>","</td>\n                            <td>"," ","</td>\n                            <td>","</td>\n                            <td>","</td>\n                        </tr>\n                    "]),a=m(["\n                    <tr>\n                        <td>","</td>\n                        <td>","</td>\n                    </tr>\n                    "],["\n                    <tr>\n                        <td>","</td>\n                        <td>","</td>\n                    </tr>\n                    "]),c=n(47),d=n(75),s=n(72),l=n(73),u=n(149),p=y(u),f=n(151),h=n(106),v=y(n(384));function y(e){return e&&e.__esModule?e:{default:e}}function m(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}l.store.addReducers({crews:p.default,athletes:v.default});var b=function(e){function t(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,(0,s.connect)(l.store)(d.PageViewElement)),r(t,[{key:"render",value:function(){return(0,c.html)(i,this._crew.name,this._compLink,this._competitionName,this._crew.startNumber,this._crew.criMax,this._athletes&&(0,h.repeat)(this._athletes,function(e){return(0,c.html)(o,e.position,e.firstName,e.lastName,e.pri,e.priMax)}),this._penalties&&(0,h.repeat)(this._penalties,function(e){return(0,c.html)(a,e.value,e.reason)}))}},{key:"stateChanged",value:function(e){if(e.app.focussedCrew&&(0,u.crewsSelector)(e)[e.app.focussedCrew]&&(this._crew=(0,u.crewsSelector)(e)[e.app.focussedCrew],this._athletes=Object.values(e.athletes.athletes)),e.app.focussedCompetition){this._compLink="/results/"+e.app.focussedCompetition;var t=e.competitions.competitionsByFriendlyName[e.app.focussedCompetition];this._competitionName=e.competitions.competitions[t].name}}}],[{key:"properties",get:function(){return{_crew:{type:Object},_competitionName:{type:String},_compLink:{type:String},_athletes:{type:Array},_penalties:{type:Array}}}}]),t}();window.customElements.define("crew-view",b),t.getCrewAthletes=f.getCrewAthletes},384:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},i=n(151),o={athletes:{},athletesByCrew:{}};t.default=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:o,t=arguments[1];switch(t.type){case i.RECEIVE_ATHLETES:return r({},e,{athletes:t.athletes});default:return e}}}}]);