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
              <b-row>
                <b-col>
                  <basic-input
                    label="Tên bệnh nhân"
                    placeholder="Nhập tên bệnh nhân"
                    name="userCode"
                    :value.sync="filter.UserCode"
                    
                  ></basic-input>
                </b-col>
                
                
                <b-col>
                  <basic-input
                    label="Số điện thoại"
                    placeholder="Nhập số điện thoại"
                    name="userPhone"
                   
                    :value.sync="filter.UserPhone"
                  ></basic-input>
                </b-col>
                
                   
                
                <b-col>
               <label>Độ tuổi</label>                 
                  <basic-input                 
                    placeholder="Từ"
                    name="name"
                    inputType="number"
                    :value.sync="filter.Username"
                  ></basic-input>
                   </b-col>              
                   <b-col>
                 <b-col></b-col>
                   <basic-input
                 
                    placeholder="Đến"
                    name="name"
                    inputType="number"
                    :value.sync="filter.Username"
                  ></basic-input>
                
                </b-col>
             
              </b-row>
              <b-row>
                 <b-col>
                  <basic-select
                    label="Gói tham gia"
                    placeholder="--- Chọn ---"
                    name="surveyType"
                    :options="isGenderOpts"
                
                    :solid="false"
                    :allowEmpty="true"
                  />
                </b-col>
                 <b-col>
                  <basic-select
                    label="Loại khảo sát"
                    placeholder="--- Chọn ---"
                    name="surveyType"
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
                    name="surveyType"
                    :options="isSurveyTypes"
                    :value.sync="filter.SurveyType"
                    :solid="false"
                    :allowEmpty="true"
                  />
                </b-col>
              
                
              </b-row>
              <b-row>
                  <b-col>
                  <basic-input
                    label="Ngày thực hiện khảo sát"
                    placeholder="Nhập tên khảo sát"
                    name="name"
                    :value.sync="filter.SurveyName"
                  ></basic-input>
                </b-col>

                 <b-col>
                  <basic-input
                    label="Ngày Import"
                    placeholder="Nhập tên khảo sát"
                    name="name"
                    :value.sync="filter.SurveyName"
                  ></basic-input>
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
              @click="resetRequest"
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
              @click="searchRequest"
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
                  :data="staff_list"
                  :paging="paging"
                  :tableAction="false"
                  :selectAction="false"
                  :searchAction="false"
                  @search="searchRequest"
                  @reset="resetRequest"
                  @sortBy="sortRequest"
                  @input="handlePageChange"
                
              >
                <template v-slot:body="{ item  }">
             
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
                  <td style=" padding-left: 25px;">{{ $moment(item.import_day* 1000).format('DD/MM/YYYY') }}</td>
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
export default {
  components: { 'user-import-modal': () => import('./components/Modal') },
 

  data() {
    return {
      selected: [],
      paging: {
        page: 1,
        pageSize: 10,
        total: 10,
      },
      filter: {
        searchKey: null,
      },
      sort: {
        by: null,
        order: null,
      },
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
      isGenderOpts: [
        { id: 1, name: 'Nam' },
        { id: 2, name: 'Nữ' },
      ],
     
    };
  },
  computed: {
    searchParams() {
      return {
       
     
        page: this.paging.page,
        size: this.paging.pageSize,
      };
    },
  },
  watch: {
      paging: {
      handler() {
        this.loadData();  
       this.handlePageChange();
      },
      deep: true,
    },
  },
  methods: {
    pagingAction() {
      this.loadData();
    },
  
    createItem() {
      this.$router.push({
        name: 'windown_import',
        params: {
          form_type: 'create',
        },
      });
    },
    viewItem(item) {
      this.$router.push({
        name: 'user_import_detail',
        params: {
          user_code : item.user_code,
          id : item.id
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
    sortRequest() {
      return;
    },
    loadData() {
       this.$store.commit('context/setLoading', true);
    this.$api.get('SurveyImportResults/user_import', {
          params: { ...this.searchParams },
        })
        .then( data  => {     
          this.staff_list = data;
       //    this.paging.total = data.total;
        //  console.log("staff "+this.staff_list , data)
        
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
      handlePageChange(value) {
      this.paging.page = value;
    },
    
    async handleImportUser() {
      this.$nextTick(() => {
        this.$bvModal.show('user-import-modal');
      });
    },
  },
  mounted() {
   // axios.get('').then((reps)=>this.list=reps.data.data)
     this.loadData()
    
  },
};
</script>
