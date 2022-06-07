<template>
  <div class="user-app-list-page w-100">
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
                    label="Mã HV"
                    placeholder="Nhập mã hv"
                    name="userCode"
                    :value.sync="filter.UserCode"
                  ></basic-input>
                </b-col>
                <b-col>
                  <basic-input
                    label="Tên HL"
                    placeholder="Nhập tên hv"
                    name="name"
                    :value.sync="filter.Username"
                  ></basic-input>
                </b-col>
                <b-col>
                  <basic-input
                    label="Số điện thoại"
                    placeholder="Nhập số điện thoại"
                    name="userPhone"
                    inputType="number"
                    :value.sync="filter.UserPhone"
                  ></basic-input>
                </b-col>
              </b-row>
              <b-row>
                <b-col>
                  <basic-select
                    label="Loại khảo sát"
                    placeholder="--- Chọn loại khảo sát ---"
                    name="surveyType"
                    :options="isSurveyTypes"
                    :value.sync="filter.SurveyType"
                    :solid="false"
                    :allowEmpty="true"
                  />
                </b-col>
                <b-col>
                  <basic-input
                    label="Tên khảo sát"
                    placeholder="Nhập tên khảo sát"
                    name="name"
                    :value.sync="filter.SurveyName"
                  ></basic-input>
                </b-col>
                <b-col>
                  <basic-select
                    label="Tình trạng báo cáo"
                    placeholder="--- Chọn tình trạng báo cáo ---"
                    name="surveyStatus"
                    :options="isSurveyStatuss"
                    :value.sync="filter.SurveyStatus"
                    :solid="false"
                    :allowEmpty="true"
                  />
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
          @click="createItemSelect"
        >
          <span class="svg-icon">
            <inline-svg src="/media/svg/icons/Neolex/Basic/upload-cloud.svg" />
          </span>
          Phân loại khách hàng
        </b-button>
        <b-button
          class="btn btn-success ml-2"
          type="button"
          @click="exportFileSelect"
        >
          <span class="svg-icon">
            <inline-svg src="/media/svg/icons/Neolex/Basic/upload-cloud.svg" />
          </span>
          Xuất file
        </b-button>
      </template>
    </basic-subheader>
    <b-overlay :show="loading">
      <b-container fluid class="user-app-list-page__body mb-6 mt-6">
        <b-row>
          <b-col>
            <div class="card card-custom gutter-b">
              <div class="card-body mt-0">
                <b-checkbox size="lg" class="m-5" v-model="selectAll">
                  Chọn tất cả
                </b-checkbox>
                <template-table
                  :column="column"
                  :data="data"
                  :paging="paging"
                  :tableAction="false"
                  :selectAction="false"
                  :searchAction="false"
                  @search="searchRequest"
                  @reset="resetRequest"
                  @sortBy="sortRequest"
                >
                  <template v-slot:body="{ item }">
                    <td
                      class="datatable-cell-center datatable-cell datatable-cell-check"
                      style="width: 20px"
                    >
                      <span style="width: 20px">
                        <label class="checkbox checkbox-single">
                          <input
                            type="checkbox"
                            :value="item"
                            v-model="selected"
                          />&nbsp;
                          <span></span>
                        </label>
                      </span>
                    </td>
                    <td>
                      {{ item.username }}
                    </td>
                    <td style="width: 20px">
                      <action-dropdown
                        :value="item"
                        @view="viewItem"
                        @edit="editItem"
                        :show_view="false"
                        :show_edit="item.surveyStatus == '1'"
                        :show_delete="false"
                        :show_copy="false"
                      >
                        <template v-if="item.surveyStatus == '0'">
                          <b-dropdown-text tag="div" class="navi-item">
                            <a
                              href="javascript:;"
                              class="navi-link text-primary"
                              @click="createItem(item)"
                            >
                              <span class="menu-icon svg-icon svg-icon-sm">
                                <inline-svg
                                  class="svg-icon"
                                  src="/media/svg/icons/Neolex/Basic/upload-cloud.svg"
                                />
                              </span>
                              <span class="navi-text text-primary"
                                >Phân loại khách hàng</span
                              >
                            </a>
                          </b-dropdown-text>
                          <b-dropdown-divider></b-dropdown-divider>
                        </template>
                        <template v-if="item.surveyStatus == '1'">
                          <b-dropdown-text tag="div" class="navi-item">
                            <a
                              href="javascript:;"
                              class="navi-link text-primary"
                              @click="exportFileItem(item)"
                            >
                              <span class="menu-icon svg-icon svg-icon-sm">
                                <inline-svg
                                  class="svg-icon"
                                  src="/media/svg/icons/Neolex/Basic/upload-cloud.svg"
                                />
                              </span>
                              <span class="navi-text text-primary"
                                >Xuất file</span
                              >
                            </a>
                          </b-dropdown-text>
                          <b-dropdown-divider></b-dropdown-divider>
                        </template>
                      </action-dropdown>
                    </td>
                    <td>
                      {{ item.surveyType }}
                    </td>
                    <td>
                      {{ item.surveyCode }}
                    </td>
                    <td>
                      {{ $moment(item.importDay * 1000).format('DD/MM/YYYY') }}
                    </td>
                    <td>
                      <span
                        class="btn btn-light btn-pill"
                        style="width: 95px; cursor: default"
                        v-if="item.surveyStatus == '0'"
                      >
                        Chưa xử lý
                      </span>
                      <span
                        class="btn btn-success btn-pill"
                        style="width: 95px; cursor: default"
                        v-if="item.surveyStatus == '1'"
                      >
                        Đã xử lý
                      </span>
                    </td>
                  </template>
                </template-table>
              </div>
            </div>
          </b-col>
        </b-row>
      </b-container>
    </b-overlay>
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
</style>

<script>
import { mapGetters } from 'vuex';
export default {
  data() {
    return {
      selected: [],
      paging: {
        page: 1,
        pageSize: 10,
        total: 0,
      },
      filter: {
        UserCode: null,
        Username: null,
        UserPhone: null,
        SurveyType: null,
        SurveyName: null,
        SurveyStatus: null,
      },
      sort: {
        by: null,
        order: null,
      },
      isSurveyTypes: [
        { id: 'Khảo sát đầu vào', name: 'Khảo sát đầu vào' },
        { id: 'Khảo sát đầu ra', name: 'Khảo sát đầu ra' },
      ],
      isSurveyStatuss: [
        { id: '0', name: 'Chưa xử lý' },
        { id: '1', name: 'Đã xử lý' },
      ],
      column: [
        {
          key: '',
          label: '',
          sortable: false,
        },
        {
          key: 'username',
          label: 'Tên HV',
          sortable: false,
        },
        {
          key: 'actionDropdown',
          label: '',
          sortable: false,
        },
        {
          key: 'surveyType',
          label: 'Loại khảo sát',
          sortable: false,
        },
        {
          key: 'surveyCode',
          label: 'Mã khảo sát',
          sortable: false,
        },
        {
          key: 'importDay',
          label: 'Ngày xử lý báo cáo',
          sortable: false,
        },
        {
          key: 'surveyStatus',
          label: 'Tình trạng báo cáo',
          sortable: false,
        },
      ],
      data: [],
      loading: false,
    };
  },
  computed: {
    ...mapGetters(['currentUser']),
    isAdmin() {
      let roles = this.currentUser?.roles;
      if (roles && roles.length) {
        return roles.includes('Admin');
      } else {
        return false;
      }
    },
    searchParams() {
      return {
        UserCode: this.filter.UserCode,
        Username: this.filter.Username,
        UserPhone: this.filter.UserPhone,
        SurveyType: this.filter.SurveyType,
        SurveyName: this.filter.SurveyName,
        SurveyStatus: this.filter.SurveyStatus,
        wardId: this.filter.wardId,
        sortBy: this.sort.by ? `${this.sort.by} ${this.sort.order}` : null,
        page: this.paging.page,
        size: this.paging.pageSize,
      };
    },
    selectAll: {
      get() {
        return (
          this.data.length > 0 && this.selected.length === this.data.length
        );
      },
      set(value) {
        if (value) {
          this.selected = [...this.data];
        } else {
          this.selected = [];
        }
      },
    },
  },
  watch: {
    paging: {
      handler() {
        this.loadData();  
      },
      deep: true,
    },
    sort: {
      handler() {
        this.loadData();
      },
      deep: true,
    },
  },
  methods: {
    pagingAction() {
      this.loadData();
    },
    searchRequest() {
      this.loadData();
    },
    resetRequest() {
      this.filter.UserCode = null;
      this.filter.Username = null;
      this.filter.UserPhone = null;
      this.filter.SurveyType = null;
      this.filter.SurveyName = null;
      this.filter.SurveyStatus = null;
      this.$nextTick(() => {
        this.$validator.reset();
      });
      this.loadData();
    },
    sortRequest(sortData) {
      this.sort = {
        by: sortData.column,
        order: sortData.order,
      };
      return;
    },
    viewItem(item) {
      this.$router.push({
        name: 'user_export_detail',
        params: {
          form_type: 'view',
          id: item.surveyResultId,
        },
      });
    },
    editItem(item) {
      this.$router.push({
        name: 'user_export_detail',
        params: {
          form_type: 'edit',
          id: item.surveyResultId,
        },
      });
    },
    createItem(item) {
      let ids = [item.id];
      this.createSurveyResult(ids);
    },
    createItemSelect() {
      let ids = this.selected
        .filter((e) => e.id)
        .map((e) => {
          return e.id;
        });
      this.createSurveyResult(ids);
    },

    exportFileItem(item) {
      let ids = [item.surveyResultId];
      this.downloadReport(ids);
    },

   exportFileSelect() 

    {

    

      let ids = this.selected
        .filter((e) => e.surveyResultId)
        .map((e) => {
          return e.surveyResultId;
        });
      if (ids.length == 0) {
        this.$toastr.e({
          title: 'Lỗi!',
          msg: 'Vui lòng hãy chọn ít nhất một báo cáo đã xử lý rồi',
        });

      } 
      
      else {
        this.downloadReport(ids);
      }
    },

    async createSurveyResult(ids) {
      this.loading = true;
      try {
        let param = {
          ids: ids,
        };
       await this.$api.put('SurveyImportChangeText/change_text',{headers: {'Content-Type': 'application/json'}})  // change text to numbers
        await this.$api
          .post(`Admin/SurveyImport/result`, param)
          .then(({ data }) => {
            this.$swal({
              text: `Xử lý thành công ${data.length}/${ids.length} báo cáo.`,
              icon: 'success',
              confirm: {
                text: 'OK',
                value: true,
                visible: true,
                className: 'btn-success',
                closeModal: false,
              },
            });
            this.loadData();
          });
      } catch (error) {
        this.$toastr.e({
          title: 'Lỗi!',
          msg: error,
        });
      } finally {
        this.loading = false;
      }
    },
    async downloadReport(ids) {

      this.loading = true;
      try {
        let param = {
          ids: ids,         
        };

         const Named_user  = await this.$api.get('SurveyImportResults/user_name',{params: { survey_result_id : ids[0] },})  // get user_name 

          //  console.log(user_name,"::::",ids[0])
        await this.$api
          .post(`Admin/SurveyImport/result/download`, param, {
            responseType: 'blob',
          })
          .then((res) => {

            let fileDonwload = window.URL.createObjectURL(res);
            var docUrl = document.createElement('a');
            docUrl.href = fileDonwload;
            if (ids.length == 1) {
          
              docUrl.setAttribute('download','baocaodauvao_'+Named_user[0].user_name.replace(/\s/g, '')+'.docx');   // remove space of username
            } else {
              docUrl.setAttribute('download', 'baocaodauvao.zip');
            }

            document.body.appendChild(docUrl);
            docUrl.click();
          });
      } catch (error) {
        this.$toastr.e({
          title: 'Lỗi!',
          msg: error,
        });
      } finally {
        this.loading = false;
      }
    },
    validateState(ref) {
      if (
        this.veeFields[ref] &&
        this.veeFields[ref].dirty &&
        this.veeFields[ref].validated
      ) {
        return this.veeFields[ref].valid;
      }
      return null;
    },
    loadData() {
      this.$store.commit('context/setLoading', true);
      this.$api
        .get('Admin/SurveyImport/list', {
          params: { ...this.searchParams },
        })
        .then(({ data }) => {
          this.selected = [];
          this.data = data.items || [];
          this.paging.total = data.total;
        })
        .catch((error) => {
          this.$toastr.e({
            title: 'Lỗi',
            msg: error,
          });
        })
        .finally(() => {
          this.$store.commit('context/setLoading', false);
        });
      return;
    },
  },
  mounted() {
    this.loadData();
  },
};
</script>
