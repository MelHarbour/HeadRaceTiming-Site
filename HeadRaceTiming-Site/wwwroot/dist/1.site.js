(window.webpackJsonp=window.webpackJsonp||[]).push([[1],{412:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.getCrew=t.getCrewPenalties=t.getCrewAwards=t.getCrewAthletes=void 0;var r=function(e,t,n){return t&&a(e.prototype,t),n&&a(e,n),e};function a(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}var o=g(['\n        <link rel="stylesheet" href="/dist/site.css">\n        ','\n\n        <basic-card headline="Crew Details">\n        <div slot="content" style="padding: 1rem">\n            <div>',"</div>\n            <div>Competition: <a href=",">","</a></div>\n            <div>Start Number: ","</div>\n            <div>CRI Max: ",'</div>\n        </div>\n        </basic-card>\n\n        <basic-card headline="Certificate">\n        <div slot="content" style="padding: 1rem">\n        <a href="/Crew/Certificate?crewId=','" download>Download</a>\n        </div>\n        </basic-card>\n\n        <basic-card headline="Athletes">\n            <table slot="content">\n                <thead>\n                    <tr><th>Seat</th><th>Name</th><th>PRI</th><th>PRIMax</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n\n        <results-card crewId=","></results-card>\n\n        <penalties-card crewId=","></penalties-card>\n\n        <awards-card crewId=","></awards-card>\n       "],['\n        <link rel="stylesheet" href="/dist/site.css">\n        ','\n\n        <basic-card headline="Crew Details">\n        <div slot="content" style="padding: 1rem">\n            <div>',"</div>\n            <div>Competition: <a href=",">","</a></div>\n            <div>Start Number: ","</div>\n            <div>CRI Max: ",'</div>\n        </div>\n        </basic-card>\n\n        <basic-card headline="Certificate">\n        <div slot="content" style="padding: 1rem">\n        <a href="/Crew/Certificate?crewId=','" download>Download</a>\n        </div>\n        </basic-card>\n\n        <basic-card headline="Athletes">\n            <table slot="content">\n                <thead>\n                    <tr><th>Seat</th><th>Name</th><th>PRI</th><th>PRIMax</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n\n        <results-card crewId=","></results-card>\n\n        <penalties-card crewId=","></penalties-card>\n\n        <awards-card crewId=","></awards-card>\n       "]),i=g(["\n                        <tr>\n                            <td>","</td>\n                            <td>"," ","</td>\n                            <td>","</td>\n                            <td>","</td>\n                        </tr>\n                    "],["\n                        <tr>\n                            <td>","</td>\n                            <td>"," ","</td>\n                            <td>","</td>\n                            <td>","</td>\n                        </tr>\n                    "]),c=n(166),s=n(415),u=n(167),l=n(168),d=n(421),f=_(d),p=n(169),h=n(432),w=n(416),b=n(418),y=n(414),v=n(419);n(420),n(444),n(445),n(447);var m=_(n(448));function _(e){return e&&e.__esModule?e:{default:e}}function g(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}l.store.addReducers({crews:f.default,athletes:m.default});var E=(function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(O,(0,u.connect)(l.store)(s.PageViewElement)),r(O,[{key:"render",value:function(){var t=this;return(0,c.html)(o,v.CardTableStyles,this._crew.name,this._compLink,this._competitionName,this._crew.startNumber,this._crew.criMax,this._crew.id,this._athletes&&(0,y.repeat)(this._athletes,function(e){return(0,c.html)(i,t._positionText(e.position),e.firstName,e.lastName,e.pri,e.priMax)}),this._crew.id,this._crew.id,this._crew.id)}},{key:"_positionText",value:function(e){switch(this._crew.boatClass){case 7:switch(e){case 1:return"Bow";case 8:return"Stroke";case 9:return"Cox";default:return e}default:return e}}},{key:"stateChanged",value:function(t){t.app.focussedCrew&&(0,d.crewsSelector)(t)[t.app.focussedCrew]&&(this._crew=(0,d.crewsSelector)(t)[t.app.focussedCrew],t.athletes.athletesByCrew[this._crew.id]&&(this._athletes=t.athletes.athletesByCrew[this._crew.id].map(function(e){return t.athletes.athletes[e]})),this._competitionName=t.competitions.competitions[this._crew.competitionId].name,this._compLink="/results/"+t.competitions.competitions[this._crew.competitionId].friendlyName)}}],[{key:"properties",get:function(){return{_crew:{type:Object},_competitionName:{type:String},_compLink:{type:String},_athletes:{type:Array}}}}]),O);function O(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,O),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(O.__proto__||Object.getPrototypeOf(O)).apply(this,arguments))}window.customElements.define("crew-view",E),t.getCrewAthletes=h.getCrewAthletes,t.getCrewAwards=w.getCrewAwards,t.getCrewPenalties=b.getCrewPenalties,t.getCrew=p.getCrew},414:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.repeat=void 0;function S(e,t){var n=e.startNode.parentNode,r=void 0===t?e.endNode:t.startNode,a=n.insertBefore((0,k.createMarker)(),r);n.insertBefore((0,k.createMarker)(),r);var o=new k.NodePart(e.options);return o.insertAfterNode(a),o}function I(e,t){return e.setValue(t),e.commit(),e}function A(e,t,n){var r=e.startNode.parentNode,a=n?n.startNode:e.endNode,o=t.endNode.nextSibling;o!==a&&(0,k.reparentNodes)(r,t.startNode,o,a)}function R(e){(0,k.removeNodes)(e.startNode.parentNode,e.startNode,e.endNode.nextSibling)}function T(e,t,n){for(var r=new Map,a=t;a<=n;a++)r.set(e[a],a);return r}var k=n(70),N=new WeakMap,x=new WeakMap;t.repeat=(0,k.directive)(function(j,e,C){var P=void 0;return void 0===C?C=e:void 0!==e&&(P=e),function(e){if(!(e instanceof k.NodePart))throw new Error("repeat can only be used in text bindings");var t=N.get(e)||[],n=x.get(e)||[],r=[],a=[],o=[],i=0,c=!0,s=!1,u=void 0;try{for(var l,d=j[Symbol.iterator]();!(c=(l=d.next()).done);c=!0){var f=l.value;o[i]=P?P(f,i):i,a[i]=C(f,i),i++}}catch(e){s=!0,u=e}finally{try{!c&&d.return&&d.return()}finally{if(s)throw u}}for(var p=void 0,h=void 0,w=0,b=t.length-1,y=0,v=a.length-1;w<=b&&y<=v;)if(null===t[w])w++;else if(null===t[b])b--;else if(n[w]===o[y])r[y]=I(t[w],a[y]),w++,y++;else if(n[b]===o[v])r[v]=I(t[b],a[v]),b--,v--;else if(n[w]===o[v])r[v]=I(t[w],a[v]),A(e,t[w],r[v+1]),w++,v--;else if(n[b]===o[y])r[y]=I(t[b],a[y]),A(e,t[b],t[w]),b--,y++;else if(void 0===p&&(p=T(o,y,v),h=T(n,w,b)),p.has(n[w]))if(p.has(n[b])){var m=h.get(o[y]),_=void 0!==m?t[m]:null;if(null===_){var g=S(e,t[w]);I(g,a[y]),r[y]=g}else r[y]=I(_,a[y]),A(e,_,t[w]),t[m]=null;y++}else R(t[b]),b--;else R(t[w]),w++;for(;y<=v;){var E=S(e,r[v+1]);I(E,a[y]),r[y++]=E}for(;w<=b;){var O=t[w++];null!==O&&R(O)}N.set(e,r),x.set(e,o)}})},415:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.PageViewElement=void 0;var r=function(e,t,n){return t&&a(e.prototype,t),n&&a(e,n),e};function a(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}var o=n(166);t.PageViewElement=(function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(i,o.LitElement),r(i,[{key:"shouldUpdate",value:function(){return this.active}}],[{key:"properties",get:function(){return{active:{type:Boolean}}}}]),i);function i(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,i),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(i.__proto__||Object.getPrototypeOf(i)).apply(this,arguments))}},416:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_AWARDS="RECEIVE_AWARDS",a=t.RECEIVE_CREW_AWARDS="RECEIVE_CREW_AWARDS",o=(t.getCompetitionAwards=function(e){return function(t){fetch("/api/competitions/"+e+"/awards").then(function(e){return e.json()}).then(function(e){return t(o(e))})}},t.getCrewAwards=function(n){return function(t){fetch("/api/crews/"+n+"/awards").then(function(e){return e.json()}).then(function(e){return t(i(e,n))})}},function(e){return{type:r,awards:e}}),i=function(e,t){return{type:a,awards:e,crewId:t}}},417:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var l="function"==typeof Symbol&&"symbol"==typeof Symbol.iterator?function(e){return typeof e}:function(e){return e&&"function"==typeof Symbol&&e.constructor===Symbol&&e!==Symbol.prototype?"symbol":typeof e};function a(e,t){return e===t}function r(e){var t=1<arguments.length&&void 0!==arguments[1]?arguments[1]:a,n=null,r=null;return function(){return function(e,t,n){if(null===t||null===n||t.length!==n.length)return!1;for(var r=t.length,a=0;a<r;a++)if(!e(t[a],n[a]))return!1;return!0}(t,n,arguments)||(r=e.apply(null,arguments)),n=arguments,r}}function o(s){for(var e=arguments.length,u=Array(1<e?e-1:0),t=1;t<e;t++)u[t-1]=arguments[t];return function(){for(var e=arguments.length,t=Array(e),n=0;n<e;n++)t[n]=arguments[n];var r=0,a=t.pop(),o=function(e){var t=Array.isArray(e[0])?e[0]:e;if(t.every(function(e){return"function"==typeof e}))return t;var n=t.map(function(e){return void 0===e?"undefined":l(e)}).join(", ");throw new Error("Selector creators expect all input-selectors to be functions, instead received the following types: ["+n+"]")}(t),i=s.apply(void 0,[function(){return r++,a.apply(null,arguments)}].concat(u)),c=s(function(){for(var e=[],t=o.length,n=0;n<t;n++)e.push(o[n].apply(null,arguments));return i.apply(null,e)});return c.resultFunc=a,c.dependencies=o,c.recomputations=function(){return r},c.resetRecomputations=function(){return r=0},c}}t.defaultMemoize=r,t.createSelectorCreator=o,t.createStructuredSelector=function(t){var e=1<arguments.length&&void 0!==arguments[1]?arguments[1]:i;if("object"!==(void 0===t?"undefined":l(t)))throw new Error("createStructuredSelector expects first argument to be an object where each property is a selector, instead received a "+(void 0===t?"undefined":l(t)));var r=Object.keys(t);return e(r.map(function(e){return t[e]}),function(){for(var e=arguments.length,t=Array(e),n=0;n<e;n++)t[n]=arguments[n];return t.reduce(function(e,t,n){return e[r[n]]=t,e},{})})};var i=t.createSelector=o(r)},418:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_PENALTIES="RECEIVE_PENALTIES",a=(t.getCrewPenalties=function(n){return function(t){fetch("/api/crews/"+n+"/penalties").then(function(e){return e.json()}).then(function(e){return t(a(e,n))})}},function(e,t){return{type:r,penalties:e,crewId:t}})},419:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.CardTableStyles=void 0;var r,a,o=(r=["\n<style>\ntable {\n    border-spacing: 0;\n    border-collapse: collapse;\n    width: 100%;\n}\n\ntr, td {\n    border-bottom: 1px rgba(0, 0, 0, 0.12) solid;\n}\n\ntr {\n    height: 48px;\n}\n\ntd, th {\n    text-align: left;\n    padding-left: 56px;\n    white-space: nowrap;\n}\n\ntd:first-child, th:first-child {\n    padding-left: 24px;\n}\n\ntd:last-child, th:last-child {\n    padding-right: 24px;\n}\n</style>\n"],a=["\n<style>\ntable {\n    border-spacing: 0;\n    border-collapse: collapse;\n    width: 100%;\n}\n\ntr, td {\n    border-bottom: 1px rgba(0, 0, 0, 0.12) solid;\n}\n\ntr {\n    height: 48px;\n}\n\ntd, th {\n    text-align: left;\n    padding-left: 56px;\n    white-space: nowrap;\n}\n\ntd:first-child, th:first-child {\n    padding-left: 24px;\n}\n\ntd:last-child, th:last-child {\n    padding-right: 24px;\n}\n</style>\n"],Object.freeze(Object.defineProperties(r,{raw:{value:Object.freeze(a)}}))),i=n(166);t.CardTableStyles=(0,i.html)(o)},420:function(e,t,n){"use strict";var r=function(e,t,n){return t&&a(e.prototype,t),n&&a(e,n),e};function a(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}var o,i,c=(o=['\n            <link rel="stylesheet" href="/dist/site.css">\n            <style>\n            .mdc-card {\n                margin: 16px;\n            }\n            .headline {\n                padding: 1rem;\n            }\n            </style>\n            <div class="mdc-card">\n                <div class="mdc-typography--headline6 headline">','</div>\n                <slot name="content"></slot>\n            </div>\n        '],i=['\n            <link rel="stylesheet" href="/dist/site.css">\n            <style>\n            .mdc-card {\n                margin: 16px;\n            }\n            .headline {\n                padding: 1rem;\n            }\n            </style>\n            <div class="mdc-card">\n                <div class="mdc-typography--headline6 headline">','</div>\n                <slot name="content"></slot>\n            </div>\n        '],Object.freeze(Object.defineProperties(o,{raw:{value:Object.freeze(i)}}))),s=n(166);var u=(function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(l,s.LitElement),r(l,[{key:"render",value:function(){return(0,s.html)(c,this.headline)}}],[{key:"properties",get:function(){return{headline:{type:String}}}}]),l);function l(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,l),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(l.__proto__||Object.getPrototypeOf(l)).apply(this,arguments))}customElements.define("basic-card",u)},421:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.crewsListSelector=t.crewsSelector=void 0;var o=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},i=n(169),c=n(416),r=n(417),s=n(418);var u={crews:{},orderedCrews:[]};t.default=function(e,t){var n=0<arguments.length&&void 0!==e?e:u,r=t;switch(r.type){case i.RECEIVE_CREWS:return o({},n,{crews:r.crews.reduce(function(e,t){return e[t.id]=t,n.crews[t.id]&&(e[t.id].awards=n.crews[t.id].awards),e},{}),orderedCrews:r.crews.map(function(e){return e.id})});case i.RECEIVE_CREW:return o({},n,{crews:o({},n.crews,function(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}({},r.crew.id,r.crew))});case c.RECEIVE_CREW_AWARDS:var a=o({},n.crews[r.crewId],{awards:r.awards.map(function(e){return e.id})});return o({},n,{crews:Object.keys(n.crews).reduce(function(e,t){return e[t]=r.crewId!==t?n.crews[t]:o({},n.crews[t],a),e},{})});case s.RECEIVE_PENALTIES:return a=o({},n.crews[r.crewId],{penalties:r.penalties.map(function(e){return e.id})}),o({},n,{crews:Object.keys(n.crews).reduce(function(e,t){return e[t]=r.crewId!==t?n.crews[t]:o({},n.crews[t],a),e},{})});default:return n}};var a=t.crewsSelector=function(e){return e.crews&&e.crews.crews};t.crewsListSelector=(0,r.createSelector)(a,function(e){return e.crews&&e.crews.orderedCrews},function(t,e){if(t)return e.map(function(e){return t[e]})})},426:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0}),t.awardsListSelector=t.awardsSelector=void 0;var a=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(416),r=n(417),i={awards:{},orderedAwards:[]};t.default=function(e,t){var n=0<arguments.length&&void 0!==e?e:i,r=t;switch(r.type){case o.RECEIVE_AWARDS:return a({},n,{awards:r.awards.reduce(function(e,t){return e[t.id]=t,e},n.awards),orderedAwards:r.awards.map(function(e){return e.id})});case o.RECEIVE_CREW_AWARDS:return a({},n,{awards:r.awards.reduce(function(e,t){return e[t.id]=t,e},n.awards)});default:return n}};var c=t.awardsSelector=function(e){return e.awards&&e.awards.awards};t.awardsListSelector=(0,r.createSelector)(c,function(e){return e.awards&&e.awards.orderedAwards},function(t,e){if(t)return e.map(function(e){return t[e]})})},432:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var r=t.RECEIVE_ATHLETES="RECEIVE_ATHLETES",a=(t.getCrewAthletes=function(n){return function(t){fetch("/api/crews/"+n+"/athletes").then(function(e){return e.json()}).then(function(e){return t(a(e,n))})}},function(e,t){return{type:r,athletes:e,crewId:t}})},444:function(e,t,n){"use strict";var r=function(e,t,n){return t&&a(e.prototype,t),n&&a(e,n),e};function a(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}var o=h(["\n        ",'\n        <basic-card headline="Section Times">\n            <table slot="content">\n            <tr><th>Point</th><th>Time of Day</th><th>Section Time</th><th>Total Time</th></tr>\n            ',"\n        </table>\n        </basic-card>\n        "],["\n        ",'\n        <basic-card headline="Section Times">\n            <table slot="content">\n            <tr><th>Point</th><th>Time of Day</th><th>Section Time</th><th>Total Time</th></tr>\n            ',"\n        </table>\n        </basic-card>\n        "]),i=h(["\n                <tr>\n                    <td>","</td>\n                    <td>","</td>\n                    <td>","</td>\n                    <td>","</td>\n                </tr>\n           "],["\n                <tr>\n                    <td>","</td>\n                    <td>","</td>\n                    <td>","</td>\n                    <td>","</td>\n                </tr>\n           "]),c=h([""," ",""],[""," ",""]),s=h([" (",")"],[" (",")"]),u=n(166),l=n(167),d=n(168),f=n(414),p=n(419);n(420);n(169);function h(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}var w=(function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(b,(0,l.connect)(d.store)(u.LitElement)),r(b,[{key:"render",value:function(){return(0,u.html)(o,p.CardTableStyles,this._results&&(0,f.repeat)(this._results,function(e){return(0,u.html)(i,e.name,e.timeOfDay,e.sectionTime,e.runTime?(0,u.html)(c,e.runTime,e.rank?(0,u.html)(s,e.rank):null):null)}))}},{key:"stateChanged",value:function(e){this._results=e.crews.crews[this.crewId].results}}],[{key:"properties",get:function(){return{crewId:{type:Number},_results:{type:Array}}}}]),b);function b(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,b),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(b.__proto__||Object.getPrototypeOf(b)).apply(this,arguments))}window.customElements.define("results-card",w)},445:function(e,t,n){"use strict";var r=function(e,t,n){return t&&a(e.prototype,t),n&&a(e,n),e};function a(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}var o,i=w(["\n        ",'\n        <basic-card headline="Penalties">\n            <table slot="content">\n                <thead>\n                    <tr><th>Amount</th><th>Reason</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n        "],["\n        ",'\n        <basic-card headline="Penalties">\n            <table slot="content">\n                <thead>\n                    <tr><th>Amount</th><th>Reason</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n        "]),c=w(["\n                    <tr><td>","</td><td>","</td></tr>\n                    "],["\n                    <tr><td>","</td><td>","</td></tr>\n                    "]),s=n(166),u=n(167),l=n(168),d=n(419),f=n(414),p=n(446),h=(o=p)&&o.__esModule?o:{default:o};function w(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}n(420),l.store.addReducers({penalties:h.default});var b=(function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(y,(0,u.connect)(l.store)(s.LitElement)),r(y,[{key:"render",value:function(){return(0,s.html)(i,d.CardTableStyles,this._penalties&&(0,f.repeat)(this._penalties,function(e){return(0,s.html)(c,e.value,e.reason)}))}},{key:"stateChanged",value:function(t){var e=t.crews.crews[this.crewId];e&&e.penalties&&(this._penalties=e.penalties.map(function(e){return t.penalties.byId[e]}))}}],[{key:"properties",get:function(){return{crewId:{type:Number},_penalties:{type:Array}}}}]),y);function y(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,y),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(y.__proto__||Object.getPrototypeOf(y)).apply(this,arguments))}window.customElements.define("penalties-card",b)},446:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var a=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(418),i={byId:{}};t.default=function(e,t){var n=0<arguments.length&&void 0!==e?e:i,r=t;switch(r.type){case o.RECEIVE_PENALTIES:return a({},n,{byId:r.penalties.reduce(function(e,t){return e[t.id]=t,e},n.byId)});default:return n}}},447:function(e,t,n){"use strict";var r=function(e,t,n){return t&&a(e.prototype,t),n&&a(e,n),e};function a(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}var o,i=w(["\n        ",'\n        <basic-card headline="Awards">\n            <table slot="content">\n                <thead>\n                    <tr><th>Title</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n        "],["\n        ",'\n        <basic-card headline="Awards">\n            <table slot="content">\n                <thead>\n                    <tr><th>Title</th></tr>\n                </thead>\n                <tbody>\n                    ',"\n                </tbody>\n            </table>\n        </basic-card>\n        "]),c=w(["\n                    <tr><td>","</td></tr>\n                    "],["\n                    <tr><td>","</td></tr>\n                    "]),s=n(166),u=n(167),l=n(168),d=n(419),f=n(414),p=n(426),h=(o=p)&&o.__esModule?o:{default:o};n(420);n(416);function w(e,t){return Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}l.store.addReducers({awards:h.default});var b=(function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(y,(0,u.connect)(l.store)(s.LitElement)),r(y,[{key:"render",value:function(){return(0,s.html)(i,d.CardTableStyles,this._awards&&(0,f.repeat)(this._awards,function(e){return(0,s.html)(c,e.title)}))}},{key:"stateChanged",value:function(t){var e=t.crews.crews[this.crewId];e&&e.awards&&(this._awards=e.awards.map(function(e){return t.awards.awards[e]}))}}],[{key:"properties",get:function(){return{crewId:{type:Number},_awards:{type:Array}}}}]),y);function y(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,y),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(y.__proto__||Object.getPrototypeOf(y)).apply(this,arguments))}window.customElements.define("awards-card",b)},448:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var a=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},o=n(432);var i={athletes:{},athletesByCrew:{}},c=function(e,t){switch(t.type){case o.RECEIVE_ATHLETES:var n=t.crewId;return a({},e,function(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}({},n,t.athletes.map(function(e){return e.id})));default:return e}};t.default=function(e,t){var n=0<arguments.length&&void 0!==e?e:i,r=t;switch(r.type){case o.RECEIVE_ATHLETES:return a({},n,{athletes:r.athletes.reduce(function(e,t){return e[t.id]=t,e},{}),athletesByCrew:c(n.athletesByCrew,r)});default:return n}}}}]);