<template>
  <div class="user-import-list-page w-100">
    <basic-subheader>
      <template v-slot:actions>
        <b-dropdown
          id="dropdown-right dropdown-form"
          class="dropdown-form-filter"
          no-caret
      
          right
        >
          <template #button-content>
            <span class="svg-icon">
              <inline-svg src="/media/svg/icons/Neolex/Basic/filter.svg" />
            </span>
            Bộ lọc
          </template>
          <h6 class="d-flex align-items-center mb-0 p-4">
            <span class="svg-icon mr-3">
              <inline-svg src="/media/svg/icons/Neolex/Basic/filter.svg" />
            </span>
            Bộ lọc
          </h6>
         <b-dropdown-divider> </b-dropdown-divider>
          <b-dropdown-form>
            <b-container class="p-0">
                <div>
              <b-row>
                <b-col>
                  <basic-input
                    label="Tên bệnh nhân"
                    placeholder="Nhập tên bệnh nhân"
                    name="userName"
                    :value.sync="filter.Username" 
                  ></basic-input>
                </b-col>
               
                <b-col>
                  <basic-input
                  
                    label="Số điện thoại"
                    placeholder="Nhập số điện thoại"
                    name="userPhone"
                    inputType="text"
                    :value.sync="filter.UserPhone"
                  ></basic-input>
                </b-col>
               
                <b-col>
                 
                 <label>Độ tuổi</label>
                 <p style="height:0px">sssssss</p>
                <div>
                  <b-row >                             
                  <basic-input   
                  
                 
                    style="width:100px"            
                    placeholder="Từ"
                    name="UserAgeFrom"
                    inputType="number"
                    :value.sync="filter.UserAgeFrom"
                  ></basic-input>
                   <p style="color:white">spa</p>
                    <basic-input
                      
                   style="width:100px"
                    placeholder="Đến"
                    name="UserAgeTo"
                    inputType="number"
                    :value.sync="filter.UserAgeTo"
                  ></basic-input>
                     </b-row>    
                </div>
                   </b-col>   
                      
              </b-row>
               </div> 
              <b-row>
                  <b-col >
                  <basic-select
                    label="Gói tham gia"
                    placeholder="--- Chọn ---"
                    name="ParticipationPackage"
                    :options="isPackage"
                    :value.sync="filter.ParticipationPackage"
                    :solid="false"
                    :allowEmpty="true"
                  />
                  <!-- <label>Gói tham gia</label>
<select class="multiselect__tags" aria-label="Default select example"  v-model="selected" :value.sync="filter.ParticipationPackage" >
  <option>--Chọn--</option>

  <option
  v-for="item in otal" :key="item" >
  {{item}}

  </option>

</select>
{{selected.valueOf()}} -->
                </b-col>
           
                 <b-col>
                  <basic-select
                    label="Loại khảo sát"
                    placeholder="--- Chọn ---"
                    name="SurveyType"
                    :options="isSurveyTypes"
                    :value.sync="filter.SurveyType"
                    :solid="false"
                    :allowEmpty="true"
                  />
                </b-col>
                <b-col>
                  <basic-select
                    label="Tên khảo sát"
                    placeholder="--- Nhập tên khảo sát ---"
                    name="SurveyName"
                    :options="isSurveyName"
                    :value.sync="filter.SurveyName"
                    :solid="false"
                    :allowEmpty="true"
                  />
                </b-col>
              
                
              </b-row>
              <b-row style="float:left"> 
                
                  <b-col>
                     <label>Ngày thực hiện khảo sát</label>
                     <b-col></b-col>
                     <b-row >

                  <basic-input
                    inputType="text"
                    style="width:175px"   
                    name="SurveyDayFrom"
                    placeholder="Từ"
                    onfocus="(this.type='date')"
                   :value.sync="filter.SurveyDayFrom"
                  ></basic-input>

                <p style="color:white">spa</p>

                   <basic-input
                    style="width:175px"   
                    placeholder="Đến"
                    name="SurveyDayTo"
                    :value.sync="filter.SurveyDayTo"
                    onfocus="(this.type='date')"
                    inputType="text"

                  ></basic-input>
                     </b-row>
                    </b-col>
                    <p style="color:white">spacespacee</p>    
                 <b-col>
                     <label>Ngày Import</label>
                      <b-col></b-col>  
                      <b-row>

                  <basic-input
                 style="width:175px"   
                    placeholder="Từ"
                    name="ImportDayFrom"
                    :value.sync="filter.ImportDayFrom"
                      onfocus="(this.type='date')"
                      inputType="text"
                    :allowEmpty="true"
                  ></basic-input>

                   <p style="color:white">spa</p>
                   <basic-input

                   style="width:175px"   
                    placeholder="Đến"
                    name="ImportDayTo"
                    :value.sync="filter.ImportDayTo"
                    onfocus="(this.type='date')"
                     inputType="text"
                  ></basic-input>
                  
                    </b-row>
                </b-col>
                   
              </b-row>
            </b-container>
          </b-dropdown-form>
          <b-dropdown-divider> </b-dropdown-divider>
          <div class="d-flex align-items-center justify-content-lg-end m-0 p-4">
            <b-button
              class="btn ml-2"
              href="#"
              tabindex="0"
              @click="resetFilter"
            >
              <span class="svg-icon">
                <inline-svg
                  src="/media/svg/icons/Neolex/Basic/refresh-cw.svg"
                />
              </span>
              Reset bộ lọc
            </b-button>
            <b-button
              class="btn ml-2"
              href="#"
              tabindex="0"
              @click="filtetest"
            >
              <span class="svg-icon">
                <inline-svg src="/media/svg/icons/Neolex/Basic/filter.svg" />
              </span>
              Lọc dữ liệu
            </b-button>
          </div>
        </b-dropdown>

        <b-button
          class="btn btn-success ml-2"
          type="button"
          id="show-btn"
         @click="handleImportUser"
        >
          Import
        </b-button>
      </template>
    </basic-subheader>
    <b-container fluid class="user-import-list-page__body mb-6 mt-6">
      <b-row>
        <b-col>
          <div class="card card-custom gutter-b">
            <div class="card-body mt-0">
              <template-table
             
                :column="column"
                  :data="filtetest()"
                  :paging="paging"
                  :tableAction="false"
                  :selectAction="false"
                  :searchAction="false"
                  @search="searchRequest"
                  @reset="resetRequest"
                  
              >
                <template v-slot:body="{ item  }"
               
                >
                      
                  <td>
                    {{ item.user_name }}
                  </td>
                  <td style="width: 20px">
                      <action-dropdown
                        :value="item"
                        @view="viewItem"
                        @edit="editItem"
                        :show_edit="false"
                        :show_delete="false"
                        :show_copy="false"
                        @copy="copyItem"
                      >
                      </action-dropdown>
                    </td>
                  <td style="padding-left: 25px;">{{ item.user_typeofsick }}</td>
                  <!-- <td style=" padding-left: 25px;">{{ $moment((item.import_day)*1000).format('DD/MM/YYYY') }}</td> -->
                  <td style=" padding-left: 25px;">{{ $moment((item.survey_day+86400)*1000).format('DD/MM/YYYY') }}</td>

                  <td>{{ item.participation_package }}</td>
                  <td>{{ item.survey_type }}</td>
                  <td>{{ item.survey_name }}<br>Mã số: {{ item.survey_code }}
                  </td>
                  <!-- <td>{{ item.user_gender }}</td>
                  <td>{{ $moment(item.survey_day).format('DD/MM/YYYY') }}</td>
                  <td>{{ item.user_province }}</td> -->
                </template>
              </template-table>
               
            </div>
          </div>
        </b-col>
      </b-row>
      
    </b-container>
    <user-import-modal :popupType="'popupType'" @loadData="loadData" />
  
  </div>
</template>

<style lang="scss" scoped>
.dropdown-form-filter {
  .dropdown-menu {
    .container {
      width: 850px;
    }
  }
}
td{
  font-family: 'Nunito';
}
</style>

<script>
//import axios from 'axios';
//import moment from 'vue-moment'
export default {
  components: { 'user-import-modal': () => import('./components/Modal') },
 

  data() {
    return {
      selected: {},
      paging: {
        page: 1,
        pageSize: 10,
        total: 10,
      },
       filter: {
        Username: null,
        UserPhone: null,
        UserAgeFrom: null,
        UserAgeTo: null,
        ParticipationPackage: null,
        SurveyType: null,
        SurveyName: null,
        ImportDayFrom: null,
       ImportDayTo: null,
        SurveyDayFrom: null,
       SurveyDayTo: null,
      },
     
      // sort: {
      //   by: null,
      //   order: null,
      // },
      list:{undefined}
      ,
      column: [
        {
          key: 'user_name',
          label: 'Bệnh nhân',
          sortable: false,
        },
         {
          key: '',
          label: '',
          sortable: false,
        },
        {
          key: 'user_typeofsick',
          label: 'Loại bệnh',
          sortable: false,
        },
        {
          key: 'survey_import',
          label: 'Ngày cập nhập',
          sortable: true,
        },
        {
          key: 'participation_package',
          label: 'Gói tham gia',
          sortable: false,
        },
        {
          key: 'survey_type',
          label: 'Loại khảo sát',
          sortable: false,
        },
        {
          key: 'survey_name',
          label: 'Tên khảo sát',
          sortable: false,
        },
      
     
      ],
      staff_list: [],
      isPackage: [],
     isSurveyName: [],   
      isSurveyTypes: [
        { id: 0, name: 'Khảo sát đầu vào' },
        { id: 1, name: 'Khảo sát đầu ra' },
      ],
    
     
    };
  },
  computed: {
     
    stafflist_total()
    {
       
       return this.staff_list.length
       
    }, 
   
   
    searchParams() {
      
      return {
       
          // sortBy: this.sort.by ? `${this.sort.by} ${this.sort.order}` : null,
        page: this.paging.page,
        size: this.paging.pageSize,
      };
    },

     filteredList() {
    //Name Filter
       if(this.filter.Username!==null)
       {
      return this.staff_list.filter((item) => item.user_name === this.filter.Username)
       }
       //phone
       if(this.filter.UserPhone!==null)
       {
      return this.staff_list.filter((item) => item.user_phone === this.filter.UserPhone)
       }
        // AGE FILTER  
       {
        
        if(this.filter.UserAgeFrom!==null&&this.filter.UserAgeTo!==null)
       {
      return this.staff_list.filter((item) => (new Date().getFullYear() - Number(item.user_yearofbirth)) >= this.filter.UserAgeFrom &&(new Date().getFullYear() - Number(item.user_yearofbirth)) <= this.filter.UserAgeTo)
       }
        if(this.filter.UserAgeFrom!==null)
       {
      return this.staff_list.filter((item) => (new Date().getFullYear() - Number(item.user_yearofbirth)) >= this.filter.UserAgeFrom)
       }
        if(this.filter.UserAgeTo!==null)
       {
      return this.staff_list.filter((item) => (new Date().getFullYear() - Number(item.user_yearofbirth)) <= this.filter.UserAgeTo)
       }
     
     /////////// IMPORT DAY FILTER
     if ((this.filter.ImportDayFrom)&&(this.filter.ImportDayTo)!==null) 
      {
         return this.staff_list.filter((item) => ((new Date(item.import_day*1000).toISOString().slice(0,10)).valueOf()>=(this.filter.ImportDayFrom).valueOf()&&((new Date(item.import_day*1000).toISOString().slice(0,10)).valueOf()<=(this.filter.ImportDayTo).valueOf())))
      }
      if (this.filter.ImportDayFrom!==null) 
      {
         return this.staff_list.filter((item) => (new Date(item.import_day*1000).toISOString().slice(0,10)).valueOf()>=(this.filter.ImportDayFrom).valueOf())
      }
       if (this.filter.ImportDayTo!==null) 
      {
         return this.staff_list.filter((item) => (new Date(item.import_day*1000).toISOString().slice(0,10)).valueOf()<=(this.filter.ImportDayTo).valueOf())
      }

       /////////// SURVEY DAY FILTER
     if ((this.filter.SurveyDayFrom)&&(this.filter.SurveyDayTo)!==null) 
      {
         return this.staff_list.filter((item) => ((new Date(item.survey_day*1000).toISOString().slice(0,10)).valueOf()>=(this.filter.SurveyDayFrom).valueOf()&&((new Date(item.survey_day*1000).toISOString().slice(0,10)).valueOf()<=(this.filter.SurveyDayTo).valueOf())))
      }
      if (this.filter.SurveyDayFrom!==null) 
      {
         return this.staff_list.filter((item) => (new Date(item.survey_day*1000).toISOString().slice(0,10)).valueOf()>=(this.filter.SurveyDayFrom).valueOf())
      }
       if (this.filter.SurveyDayTo!==null) 
      {
         return this.staff_list.filter((item) => (new Date(item.survey_day*1000).toISOString().slice(0,10)).valueOf()<=(this.filter.SurveyDayTo).valueOf())
      }
       if (this.filter.ParticipationPackage!==null) 
      {
         
          return this.staff_list.filter((item) => item.participation_package === this.isPackage[this.filter.ParticipationPackage].name)
         
      }
      if (this.filter.SurveyName!==null) 
      {
         
          return this.staff_list.filter((item) => item.survey_name === this.isSurveyName[this.filter.SurveyName].name)
         
      }

       if (this.filter.SurveyType!==null) 
      {
        return this.staff_list.filter((item) => item.survey_type === this.isSurveyTypes[this.filter.SurveyType].name)
         
      }
       

// {{selected.valueOf()}}
       }
    return 0
    },

    
  },
  watch: {
      paging: {
      handler() {
        this.loadData();  
      // this.handlePageChange();
      },
      deep: true,
    },
     
  },
  methods: {


    pagingAction() {
      this.loadData();
    },
  
    
    viewItem(item) {
      this.$router.push({
        name: 'user_import_detail',
        params: {
          user_code : item.user_code,
          id : item.id,
          survey_code :  item.survey_code
        },
      });
    },
    editItem(item) {
      this.$router.push({
        name: 'user_group_detail',
        params: {
          form_type: 'edit',
          id: item.id,
        },
      });
    },
    searchRequest() {
      //this.loadData();
    },
    resetRequest() {
      this.filter.searchKey = null;
      this.$nextTick(() => {
        this.$validator.reset();
      });
      this.loadData();
    },

      dateSort(a, b) {
      let date1 = new Date(a.survey_day).getTime();
      let date2 = new Date(b.survey_day).getTime();
      
      return date1 - date2;
    },
    //   sortRequest(sortData) {
    //   this.sort = {
    //     by: sortData.column,
    //     order: sortData.order,
    //   };
    //   return;
    // },
  //    sortedData() {
  //    return this.staff_list.sort(function(a, b) {
  //       return a.name > b.name;
  //    });
  // },

    loadData() {
       this.$store.commit('context/setLoading', true);
    this.$api.get('SurveyImportResults/user_import', {
          params: { ...this.searchParams },
          
        })
        .then( data  => {     
          this.staff_list = data; 
  
        
        }).catch((error) => {
          this.$toastr.e({
            title: 'Lỗi',
            msg: error,
          });
        })
        .finally(() => {
          this.$store.commit('context/setLoading', false);
        });
        
    },
    //   handlePageChange(value) {
    //   this.paging.page = value;
    // },
    
    async handleImportUser() {
      this.$nextTick(() => {
        this.$bvModal.show('user-import-modal');
      });
    },
     resetFilter() {
        this.filter.Username = null,
        this.filter.UserPhone= null,
        this.filter. UserAgeFrom= null,
        this.filter. UserAgeTo= null,
        this.filter.ParticipationPackage= null,
        this.filter.SurveyType= null,
        this.filter.SurveyName= null,
        this.filter.ImportDayFrom= null,
      this.filter.ImportDayTo= null,
        this.filter.SurveyDayFrom= null,
        this.filter.SurveyDayTo= null,
        this.paging.size = 10
        
      },
     
     filtetest()
      {
       if((this.filter.Username||this.filter.UserPhone||this.filter.UserAgeFrom||this.filter.UserAgeTo||this.filter.ParticipationPackage
        ||this.filter.SurveyType||this.filter.SurveyName
        ||this.filter.ImportDayFrom||this.filter.ImportDayTo||this.filter.SurveyDayFrom||this.filter.SurveyDayTo)!==null)
     //   if(this.filter.Username===null)
        {
                        this.addID()         
           return this.filteredList;
         
        }
        else{
                           //     
        this.addID()
        return this.staff_list
        }
      },


  elimited: function()
   {    
    return this.staff_list.filter((item, pos, self) => self.findIndex(v => v.participation_package === item.participation_package) === pos);
    },

        elimited2: function()
   {    
    return this.staff_list.filter((item, pos, self) => self.findIndex(v => v.survey_name === item.survey_name) === pos);
    },

     addID()
      {
      
        for(let v=0;v<Number(this.elimited().length);v++)
        {
           this.isPackage[v]={'id':[v],'name':this.elimited()[v].participation_package}
        
        }
        for(let v=0;v<Number(this.elimited2().length);v++)
        {

           this.isSurveyName[v]={'id':[v],'name':this.elimited2()[v].survey_name}
        }
   
       
       
      
      },
   
  },
  mounted() {
   // axios.get('').then((reps)=>this.list=reps.data.data)
  
     this.loadData()
    
  },
};
</script>
