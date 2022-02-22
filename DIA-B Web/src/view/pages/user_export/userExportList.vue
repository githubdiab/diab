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
                    label="Mã bệnh nhân"
                    placeholder="Nhập mã bệnh nhân"
                    name="code"
                    :value.sync="filter.UserCode"
                  ></basic-input>
                </b-col>
                <b-col>
                  <basic-input
                    label="Tên HL"
                    placeholder="Nhập tên bệnh nhân"
                    name="name"
                    :value.sync="filter.Username"
                  ></basic-input>
                </b-col>
                <b-col>
                  <basic-input
                    label="Số điện thoại"
                    placeholder="Nhập số điện thoại"
                    name="name"
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
                    name="userGroup"
                    :options="[]"
                    :value.sync="filter.SurveyType"
                    :solid="false"
                    :allowEmpty="true"
                  />
                </b-col>
                <b-col>
                  <basic-select
                    label="Tên khảo sát"
                    placeholder="--- Chọn tên khảo sát ---"
                    name="nation"
                    :apiPath="'/Division/Nations'"
                    :searchField="'searchTerm'"
                    :value.sync="filter.SurveyName"
                    :solid="false"
                    :allowEmpty="true"
                  />
                </b-col>
                <b-col>
                  <basic-select
                    label="Tình trạng báo cáo"
                    placeholder="--- Chọn tình trạng báo cáo ---"
                    name="province"
                    :apiPath="'/Division/Provinces'"
                    :searchField="'searchTerm'"
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
          @click="importItems"
        >
          <span class="svg-icon">
            <inline-svg src="/media/svg/icons/Neolex/Basic/upload-cloud.svg" />
          </span>
          Import danh sách
        </b-button>
        <b-button
          class="btn btn-success ml-2"
          type="button"
          @click="createItem"
          v-if="isAdmin"
        >
          <span class="svg-icon">
            <inline-svg src="/media/svg/icons/Neolex/Basic/plus.svg" />
          </span>
          Thêm tài khoản
        </b-button>
      </template>
    </basic-subheader>
    <b-overlay :show="loading">
      <b-container fluid class="user-app-list-page__body mb-6 mt-6">
        <b-row>
          <b-col>
            <div class="card card-custom gutter-b">
              <div class="card-body mt-0">
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
                    <td>
                      <div class="d-flex align-items-center mt-5">
                        <avatar
                          size="40px"
                          :text="item.fullName"
                          :src="item.avatar && item.avatar.url"
                          :rounded="true"
                        ></avatar>
                        <div class="d-flex flex-column ml-5">
                          <p
                            class="mb-0"
                            style="
                              font-weight: 600;
                              font-size: 13px;
                              color: #515356;
                            "
                          >
                            {{ item.fullName }}
                          </p>
                          <p
                            class="mt-2 mb-0"
                            style="font-size: 12px; color: #888c9f"
                          >
                            {{ item.username }}
                          </p>
                        </div>
                      </div>
                    </td>
                    <td style="width: 20px">
                      <action-dropdown
                        :value="item"
                        @view="viewItem"
                        @edit="editItem"
                        :show_edit="true"
                        :show_delete="false"
                        :show_copy="false"
                        @copy="copyItem"
                      >
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
                        class="btn btn-inactive btn-pill"
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
      isActiveOpts: [
        { id: true, name: 'Active' },
        { id: false, name: 'Inactive' },
      ],
      isGenderOpts: [
        { id: 1, name: 'Nam' },
        { id: 2, name: 'Nữ' },
      ],
      column: [
        {
          key: 'username',
          label: 'Nhân viên',
          sortable: true,
        },
        {
          key: 'actionDropdown',
          label: '',
          sortable: false,
        },
        {
          key: 'surveyType',
          label: 'Loại báo cáo',
          sortable: true,
        },
        {
          key: 'surveyCode',
          label: 'Mã khảo sát',
          sortable: false,
        },
        {
          key: 'importDay',
          label: 'Ngày xử lý báo cáo',
          sortable: true,
        },
        {
          key: 'surveyStatus',
          label: 'Tình trạng báo cáo',
          sortable: true,
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
        name: 'user_portal_view',
        params: {
          id: item.id,
        },
      });
    },
    editItem(item) {
      this.$router.push({
        name: 'user_portal_detail',
        params: {
          form_type: 'edit',
          id: item.id,
        },
      });
    },
    createItem() {
      this.$router.push({
        name: 'user_portal_detail',
        params: {
          form_type: 'create',
        },
      });
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
    importItems() {},
    deleteItem(item) {
      let text = item.isActive ? 'Inactive' : 'Active';
      let btn = item.isActive ? 'btn-inactive' : 'btn-active';
      this.$swal({
        title: '',
        text: `Bạn có chắc muốn ${text} app user ${item.fullName} không?`,
        icon: '/media/svg/icons/SweetAlert/alert-triangle-red.svg',
        buttons: {
          cancel: {
            text: 'Quay lại',
            value: false,
            visible: true,
            className: 'btn btn-secondary',
            closeModal: true,
          },
          confirm: {
            text: `${text}`,
            value: true,
            visible: true,
            className: `btn ${btn}`,
            closeModal: true,
          },
        },
      }).then(
        function (result) {
          if (result) {
            // inactive all
            this.inactiveItem(item)
              .then(() => {
                this.loadData();
                this.$swal(
                  'Thành công!',
                  'Chúc mừng, bạn đã cập nhật thông tin người dùng thành công!',
                  'success',
                );
              })
              .catch(() => {
                this.$swal('Lỗi!', 'Đã có lỗi xảy ra.', 'error');
              });
          }
        }.bind(this),
      );
    },
    copyItem(item) {
      this.$router.push({
        name: 'user_portal_detail',
        params: {
          form_type: 'copy',
          id: item.id,
        },
      });
    },

    async inactiveItem(item) {
      this.loading = true;
      try {
        let payload = new FormData();
        payload.append('id', item.id);
        payload.append('active', !item.isActive);
        await this.$api.put(`Admin/Account/portal`, payload);
      } catch (error) {
        this.$toastr.e({
          title: 'Lỗi!',
          msg: error,
        });
      } finally {
        this.loading = false;
      }
    },
    loadData() {
      this.$store.commit('context/setLoading', true);
      this.$api
        .get('Admin/SurveyImport/list', {
          params: { ...this.searchParams },
        })
        .then(({ data }) => {
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
