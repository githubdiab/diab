(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-08f43b14"],{"556d":function(t,e,s){},db64:function(t,e,s){"use strict";s.r(e);var a=function(){var t=this,e=t.$createElement,s=t._self._c||e;return s("div",{staticClass:"user-app-list-page w-100"},[s("basic-subheader",{scopedSlots:t._u([{key:"actions",fn:function(){return[s("b-dropdown",{staticClass:"dropdown-form-filter",attrs:{id:"dropdown-right dropdown-form","no-caret":"",right:""},scopedSlots:t._u([{key:"button-content",fn:function(){return[s("span",{staticClass:"svg-icon"},[s("inline-svg",{attrs:{src:"/media/svg/icons/Neolex/Basic/filter.svg"}})],1),t._v(" Bộ lọc ")]},proxy:!0}])},[s("h6",{staticClass:"d-flex align-items-center mb-0 p-4"},[s("span",{staticClass:"svg-icon mr-3"},[s("inline-svg",{attrs:{src:"/media/svg/icons/Neolex/Basic/filter.svg"}})],1),t._v(" Bộ lọc ")]),s("b-dropdown-divider"),s("b-dropdown-form",[s("b-container",{staticClass:"p-0"},[s("b-row",[s("b-col",[s("basic-input",{attrs:{label:"Mã HV",placeholder:"Nhập mã hv",name:"userCode",value:t.filter.UserCode},on:{"update:value":function(e){return t.$set(t.filter,"UserCode",e)}}})],1),s("b-col",[s("basic-input",{attrs:{label:"Tên HL",placeholder:"Nhập tên hv",name:"name",value:t.filter.Username},on:{"update:value":function(e){return t.$set(t.filter,"Username",e)}}})],1),s("b-col",[s("basic-input",{attrs:{label:"Số điện thoại",placeholder:"Nhập số điện thoại",name:"userPhone",inputType:"number",value:t.filter.UserPhone},on:{"update:value":function(e){return t.$set(t.filter,"UserPhone",e)}}})],1)],1),s("b-row",[s("b-col",[s("basic-select",{attrs:{label:"Loại khảo sát",placeholder:"--- Chọn loại khảo sát ---",name:"surveyType",options:t.isSurveyTypes,value:t.filter.SurveyType,solid:!1,allowEmpty:!0},on:{"update:value":function(e){return t.$set(t.filter,"SurveyType",e)}}})],1),s("b-col",[s("basic-input",{attrs:{label:"Tên khảo sát",placeholder:"Nhập tên khảo sát",name:"name",value:t.filter.SurveyName},on:{"update:value":function(e){return t.$set(t.filter,"SurveyName",e)}}})],1),s("b-col",[s("basic-select",{attrs:{label:"Tình trạng báo cáo",placeholder:"--- Chọn tình trạng báo cáo ---",name:"surveyStatus",options:t.isSurveyStatuss,value:t.filter.SurveyStatus,solid:!1,allowEmpty:!0},on:{"update:value":function(e){return t.$set(t.filter,"SurveyStatus",e)}}})],1)],1)],1)],1),s("b-dropdown-divider"),s("div",{staticClass:"d-flex align-items-center justify-content-lg-end m-0 p-4"},[s("b-button",{staticClass:"btn ml-2",attrs:{href:"#",tabindex:"0"},on:{click:t.resetRequest}},[s("span",{staticClass:"svg-icon"},[s("inline-svg",{attrs:{src:"/media/svg/icons/Neolex/Basic/refresh-cw.svg"}})],1),t._v(" Reset bộ lọc ")]),s("b-button",{staticClass:"btn ml-2",attrs:{href:"#",tabindex:"0"},on:{click:t.searchRequest}},[s("span",{staticClass:"svg-icon"},[s("inline-svg",{attrs:{src:"/media/svg/icons/Neolex/Basic/filter.svg"}})],1),t._v(" Lọc dữ liệu ")])],1)],1),s("b-button",{staticClass:"btn btn-success ml-2",attrs:{type:"button"},on:{click:t.createItemSelect}},[s("span",{staticClass:"svg-icon"},[s("inline-svg",{attrs:{src:"/media/svg/icons/Neolex/Basic/upload-cloud.svg"}})],1),t._v(" Phân loại khách hàng ")]),s("b-button",{staticClass:"btn btn-success ml-2",attrs:{type:"button"},on:{click:t.exportFileSelect}},[s("span",{staticClass:"svg-icon"},[s("inline-svg",{attrs:{src:"/media/svg/icons/Neolex/Basic/upload-cloud.svg"}})],1),t._v(" Xuất file ")])]},proxy:!0}])}),s("b-overlay",{attrs:{show:t.loading}},[s("b-container",{staticClass:"user-app-list-page__body mb-6 mt-6",attrs:{fluid:""}},[s("b-row",[s("b-col",[s("div",{staticClass:"card card-custom gutter-b"},[s("div",{staticClass:"card-body mt-0"},[s("b-checkbox",{staticClass:"m-5",attrs:{size:"lg"},model:{value:t.selectAll,callback:function(e){t.selectAll=e},expression:"selectAll"}},[t._v(" Chọn tất cả ")]),s("template-table",{attrs:{column:t.column,data:t.data,paging:t.paging,tableAction:!1,selectAction:!1,searchAction:!1},on:{search:t.searchRequest,reset:t.resetRequest,sortBy:t.sortRequest},scopedSlots:t._u([{key:"body",fn:function(e){var a=e.item;return[s("td",{staticClass:"datatable-cell-center datatable-cell datatable-cell-check",staticStyle:{width:"20px"}},[s("span",{staticStyle:{width:"20px"}},[s("label",{staticClass:"checkbox checkbox-single"},[s("input",{directives:[{name:"model",rawName:"v-model",value:t.selected,expression:"selected"}],attrs:{type:"checkbox"},domProps:{value:a,checked:Array.isArray(t.selected)?t._i(t.selected,a)>-1:t.selected},on:{change:function(e){var s=t.selected,i=e.target,n=!!i.checked;if(Array.isArray(s)){var r=a,l=t._i(s,r);i.checked?l<0&&(t.selected=s.concat([r])):l>-1&&(t.selected=s.slice(0,l).concat(s.slice(l+1)))}else t.selected=n}}}),t._v(" "),s("span")])])]),s("td",[t._v(" "+t._s(a.username)+" ")]),s("td",{staticStyle:{width:"20px"}},[s("action-dropdown",{attrs:{value:a,show_view:!1,show_edit:"1"==a.surveyStatus,show_delete:!1,show_copy:!1},on:{view:t.viewItem,edit:t.editItem}},["0"==a.surveyStatus?[s("b-dropdown-text",{staticClass:"navi-item",attrs:{tag:"div"}},[s("a",{staticClass:"navi-link text-primary",attrs:{href:"javascript:;"},on:{click:function(e){return t.createItem(a)}}},[s("span",{staticClass:"menu-icon svg-icon svg-icon-sm"},[s("inline-svg",{staticClass:"svg-icon",attrs:{src:"/media/svg/icons/Neolex/Basic/upload-cloud.svg"}})],1),s("span",{staticClass:"navi-text text-primary"},[t._v("Phân loại khách hàng")])])]),s("b-dropdown-divider")]:t._e(),"1"==a.surveyStatus?[s("b-dropdown-text",{staticClass:"navi-item",attrs:{tag:"div"}},[s("a",{staticClass:"navi-link text-primary",attrs:{href:"javascript:;"},on:{click:function(e){return t.exportFileItem(a)}}},[s("span",{staticClass:"menu-icon svg-icon svg-icon-sm"},[s("inline-svg",{staticClass:"svg-icon",attrs:{src:"/media/svg/icons/Neolex/Basic/upload-cloud.svg"}})],1),s("span",{staticClass:"navi-text text-primary"},[t._v("Xuất file")])])]),s("b-dropdown-divider")]:t._e()],2)],1),s("td",[t._v(" "+t._s(a.surveyType)+" ")]),s("td",[t._v(" "+t._s(a.surveyCode)+" ")]),s("td",[t._v(" "+t._s(t.$moment(1e3*a.importDay).format("DD/MM/YYYY"))+" ")]),s("td",["0"==a.surveyStatus?s("span",{staticClass:"btn btn-light btn-pill",staticStyle:{width:"95px",cursor:"default"}},[t._v(" Chưa xử lý ")]):t._e(),"1"==a.surveyStatus?s("span",{staticClass:"btn btn-success btn-pill",staticStyle:{width:"95px",cursor:"default"}},[t._v(" Đã xử lý ")]):t._e()])]}}])})],1)])])],1)],1)],1)],1)},i=[],n=(s("99af"),s("4de4"),s("caad"),s("d81d"),s("d3b7"),s("2532"),s("3ca3"),s("ddb0"),s("2b3d"),s("96cf"),s("1da1")),r=s("2909"),l=s("5530"),o=s("2f62"),c={data:function(){return{selected:[],paging:{page:1,pageSize:10,total:0},filter:{UserCode:null,Username:null,UserPhone:null,SurveyType:null,SurveyName:null,SurveyStatus:null},sort:{by:null,order:null},isSurveyTypes:[{id:"Khảo sát đầu vào",name:"Khảo sát đầu vào"},{id:"Khảo sát đầu ra",name:"Khảo sát đầu ra"}],isSurveyStatuss:[{id:"0",name:"Chưa xử lý"},{id:"1",name:"Đã xử lý"}],column:[{key:"",label:"",sortable:!1},{key:"username",label:"Tên HV",sortable:!1},{key:"actionDropdown",label:"",sortable:!1},{key:"surveyType",label:"Loại khảo sát",sortable:!1},{key:"surveyCode",label:"Mã khảo sát",sortable:!1},{key:"importDay",label:"Ngày xử lý báo cáo",sortable:!1},{key:"surveyStatus",label:"Tình trạng báo cáo",sortable:!1}],data:[],loading:!1}},computed:Object(l["a"])(Object(l["a"])({},Object(o["c"])(["currentUser"])),{},{isAdmin:function(){var t,e=null===(t=this.currentUser)||void 0===t?void 0:t.roles;return!(!e||!e.length)&&e.includes("Admin")},searchParams:function(){return{UserCode:this.filter.UserCode,Username:this.filter.Username,UserPhone:this.filter.UserPhone,SurveyType:this.filter.SurveyType,SurveyName:this.filter.SurveyName,SurveyStatus:this.filter.SurveyStatus,wardId:this.filter.wardId,sortBy:this.sort.by?"".concat(this.sort.by," ").concat(this.sort.order):null,page:this.paging.page,size:this.paging.pageSize}},selectAll:{get:function(){return this.data.length>0&&this.selected.length===this.data.length},set:function(t){this.selected=t?Object(r["a"])(this.data):[]}}}),watch:{paging:{handler:function(){this.loadData()},deep:!0},sort:{handler:function(){this.loadData()},deep:!0}},methods:{pagingAction:function(){this.loadData()},searchRequest:function(){this.loadData()},resetRequest:function(){var t=this;this.filter.UserCode=null,this.filter.Username=null,this.filter.UserPhone=null,this.filter.SurveyType=null,this.filter.SurveyName=null,this.filter.SurveyStatus=null,this.$nextTick((function(){t.$validator.reset()})),this.loadData()},sortRequest:function(t){this.sort={by:t.column,order:t.order}},viewItem:function(t){this.$router.push({name:"user_export_detail",params:{form_type:"view",id:t.surveyResultId}})},editItem:function(t){this.$router.push({name:"user_export_detail",params:{form_type:"edit",id:t.surveyResultId}})},createItem:function(t){var e=[t.id];this.createSurveyResult(e)},createItemSelect:function(){var t=this.selected.filter((function(t){return t.id})).map((function(t){return t.id}));this.createSurveyResult(t)},exportFileItem:function(t){var e=[t.surveyResultId];this.downloadReport(e)},exportFileSelect:function(){var t=this.selected.filter((function(t){return t.surveyResultId})).map((function(t){return t.surveyResultId}));0==t.length?this.$toastr.e({title:"Lỗi!",msg:"Vui lòng hãy chọn ít nhất một báo cáo đã xử lý rồi"}):this.downloadReport(t)},createSurveyResult:function(t){var e=this;return Object(n["a"])(regeneratorRuntime.mark((function s(){var a;return regeneratorRuntime.wrap((function(s){while(1)switch(s.prev=s.next){case 0:return e.loading=!0,s.prev=1,a={ids:t},s.next=5,e.$api.post("Admin/SurveyImport/result",a).then((function(s){var a=s.data;e.$swal({text:"Xử lý thành công ".concat(a.length,"/").concat(t.length," báo cáo."),icon:"success",confirm:{text:"OK",value:!0,visible:!0,className:"btn-success",closeModal:!1}}),e.loadData()}));case 5:s.next=10;break;case 7:s.prev=7,s.t0=s["catch"](1),e.$toastr.e({title:"Lỗi!",msg:s.t0});case 10:return s.prev=10,e.loading=!1,s.finish(10);case 13:case"end":return s.stop()}}),s,null,[[1,7,10,13]])})))()},downloadReport:function(t){var e=this;return Object(n["a"])(regeneratorRuntime.mark((function s(){var a;return regeneratorRuntime.wrap((function(s){while(1)switch(s.prev=s.next){case 0:return e.loading=!0,s.prev=1,a={ids:t},s.next=5,e.$api.post("Admin/SurveyImport/result/download",a,{responseType:"blob"}).then((function(e){var s=window.URL.createObjectURL(e),a=document.createElement("a");a.href=s,1==t.length?a.setAttribute("download","bao_cao_dau_ra.docx"):a.setAttribute("download","bao_cao_dau_ra.zip"),document.body.appendChild(a),a.click()}));case 5:s.next=10;break;case 7:s.prev=7,s.t0=s["catch"](1),e.$toastr.e({title:"Lỗi!",msg:s.t0});case 10:return s.prev=10,e.loading=!1,s.finish(10);case 13:case"end":return s.stop()}}),s,null,[[1,7,10,13]])})))()},validateState:function(t){return this.veeFields[t]&&this.veeFields[t].dirty&&this.veeFields[t].validated?this.veeFields[t].valid:null},loadData:function(){var t=this;this.$store.commit("context/setLoading",!0),this.$api.get("Admin/SurveyImport/list",{params:Object(l["a"])({},this.searchParams)}).then((function(e){var s=e.data;t.selected=[],t.data=s.items||[],t.paging.total=s.total})).catch((function(e){t.$toastr.e({title:"Lỗi",msg:e})})).finally((function(){t.$store.commit("context/setLoading",!1)}))}},mounted:function(){this.loadData()}},u=c,d=(s("e49a"),s("2877")),v=Object(d["a"])(u,a,i,!1,null,"6db29cbf",null);e["default"]=v.exports},e49a:function(t,e,s){"use strict";s("556d")}}]);
//# sourceMappingURL=chunk-08f43b14.a067c074.js.map