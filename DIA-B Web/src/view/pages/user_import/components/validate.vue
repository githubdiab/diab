<template>
  <div class="user-import-list-page w-100">
    <b-container fluid class="user-import-list-page__body mb-6 mt-6">
      <b-row>
        <b-col>
          <div class="card card-custom gutter-b">
            <div class="card-body mt-0">
              <div id="container">
                <div class="inline">
                  <p v-if="column">
                  <span class="svg-icon">
                  <inline-svg src="/media/svg/import/group.svg" />
                  </span>
                    Tổng số bản ghi bị lỗi : {{ tableLength }}
                  </p>
                </div>
                <div class="inline">
                  <p v-if="column">
                    <span class="svg-icon">
                  <inline-svg src="/media/svg/import/group.svg" />
                  </span>
                    Tổng số khách hàng bị ảnh hưởng : {{ tableLength }}
                  </p>
                </div>
              </div>
              <template-table
                :column="column"
                :data="staff_list"
                :paging="paging"
                :tableAction="false"
                :selectAction="false"
                :searchAction="false"
                @sortBy="sortRequest"
              >
                <template v-slot:body="{ item }">
                  <td v-if="item.user_code.length!=0" >{{"0"+ item.stt }}</td>
                  <td >{{ item.user_name }}</td> 
                  <td v-show="item.user_name.length==0" style="color:blue">{{  "Thiếu tên" }}</td>

                  <td v-show="item.user_code.length!=0">{{ item.user_code }}</td>
           
                  <td v-show="item.user_gender.length==0">{{item.stt}}</td>
                  <td v-show="item.user_gender.length==0">{{"Giới tính"}}</td>
                  <td v-show="item.user_gender.length==0" style="color:red">{{ "thiếu thông tin giới tính" }}</td>

                  <td v-show="item.user_address.length==0">{{item.stt}}</td>
                  <td v-show="item.user_address.length==0">{{"Địa chỉ"}}</td>
                  <td v-show="item.user_address.length==0" style="color:red">{{ "thiếu thông tin địa chỉ" }}</td>
        
               <!-- <td >{{ user_code2 }}</td> -->
                </template>
              </template-table>

              <b-button
                class="btn btn-success ml-2"
                type="button"
                style="float: right"
                @click="$router.go(-2)"
              >
                Hủy
              </b-button>

              <b-button
                class="btn btn-success ml-2"
                type="button"
                style="float: right"
              >
                Tiếp tục
              </b-button>
            </div>
          </div>
        </b-col>
      </b-row>
    </b-container>
  </div>


</template>
<style lang="scss" scoped>
.dropdown-form-filter {
  .dropdown-menu {
    .container {
      width: 430px;
    }
  }
}
td {
  white-space: nowrap;
  word-wrap: normal;
  overflow: hidden;
  text-overflow: ellipsis;
  text-align: center;
  width: 50px;
}

table {
  width: 100%;
  table-layout: fixed;
}
div {
  white-space: nowrap;
  word-wrap: normal;
  text-align: center;
}
p {
  text-align: left;
}
.inline {
  display: inline-block;
  //border: 1px solid red;
  margin: 10px;
  text-align: left;
}
#container {
  display: flex; /* establish flex container */
  flex-direction: row; /* default value; can be omitted */
  flex-wrap: nowrap; /* default value; can be omitted */
  // justify-content: space-between; /* switched from default (flex-start, see below) */
  // background-color: lightyellow;
}
// data {
//   white-space: nowrap;
// }
</style>

<script>
export default {
  props: {
    staff_list: {
      type: Array,
      default: () => [],
    },
  },
  data() {
    return {
      paging: {
        page: 1,
        pageSize: 10,
        total: 0,
      },
      filter: {
        searchKey: null,
      },
      sort: {
        by: null,
        order: null,
      },
      column: [
        {
          key: 'stt',
          label: 'STT',
          sortable: false,
        },
        {
          key: 'user_name',
          label: 'Họ tên',
          sortable: false,
        },
        {
          key: 'user_code',
          label: 'Mã khách hàng',
          sortable: false,
        },
        {
          key: 'row_error',
          label: 'Hàng có lỗi',
          sortable: false,
        },
        {
              key: 'column_error',
          label: 'Cột có lỗi',
          sortable: false,
        },
        {
           key: 'detail_error',
          label: 'Chi tiết lỗi',
          sortable: false,
        },
      ],
      data: [],
    };
  },
  computed: {
    searchParams() {
      return {
        searchKey: this.filter.searchKey,
        page: this.paging.page,
        size: this.paging.pageSize,
      };
    },
    tableLength: function () {
      
   //   var totalcount = this.staff_list.length;
      
      return 0;
    },
  },
  created() {},
  watch: {
    'paging.page'() {
      //this.loadData();
    },
    'paging.pageSize'() {
      //this.loadData();
    },
    sort: {},
  },
  methods: {
    
  },
  mounted() {
    // this.loadData();
  },

  // getdatafrommodal()
  // {
  //   this.$root.$emit('Modal')
  // }
};
</script>
