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
                :@click="get_column_error"
              >
                <template v-slot:body="{ item }">
          
               <!-- show stt   -->
                  <td v-show="item.length!=0" >{{"0"+ item.stt }}</td>
                   <!-- <td v-show="item.length!=0" >{{""}}</td> -->


              <!-- show name   -->
                  <td v-show="item.user_gender.length!=0" >{{ item.user_name }}</td> 
                    <!-- <td v-show="item.user_gender.length!=0" >{{ "" }}</td>  -->
              <!-- show code   -->
                  <td v-show="item.user_gender.length!=0">{{ item.user_code }}</td>
                  <!-- <td v-show="item.user_gender.length!=0">{{ "" }}</td> -->
           
                  <!-- show row error  -->
                     <td v-show="item.user_gender.length==0">{{item.stt}}</td>
                  <td v-show="item.user_name.length==0">{{item.stt}}</td>
                 
                  <td v-show="item.user_address.length==0">{{item.stt}}</td>
                   <td v-show="item.user_code.length==0">{{item.stt}}</td>
                  <td v-show="item.user_phone.length==0">{{item.stt}}</td>

                   <td v-show="item.survey_type.length==0">{{item.stt}}</td>
                  <td v-show="item.survey_name.length==0">{{item.stt}}</td>
                   <td v-show="item.survey_code.length==0">{{item.stt}}</td>
                   <td v-show="item.user_yearofbirth.length==0">{{item.stt}}</td>
                   <td v-show="item.survey_day.length==0">{{item.stt}}</td>
                   <td v-show="item.user_province.length==0">{{item.stt}}</td>
                   <td v-show="item.user_career.length==0">{{item.stt}}</td>
                   <td v-show="item.user_hoobit.length==0">{{item.stt}}</td>
                   <td v-show="item.story_success.length==0">{{item.stt}}</td>
                   <td v-show="item.course_goal.length==0">{{item.stt}}</td>
                   <td v-show="item.course_action.length==0">{{item.stt}}</td>
                   <td v-show="item.course_final_rate.length==0">{{item.stt}}</td>
                   <td v-show="item.user_typeofsick.length==0">{{item.stt}}</td>
                   <td v-show="item.year_foundout.length==0">{{item.stt}}</td>
                   <td v-show="item.participation_package.length==0">{{item.stt}}</td>
                   <td v-show="item.survey_type_code.length==0">{{item.stt}}</td>
                   <td v-show="item.category_code.length==0">{{item.stt}}</td>
                   <td v-show="item.category.length==0">{{item.stt}}</td>
                   <td v-show="item.sub_category_code.length==0">{{item.stt}}</td>
                   <td v-show="item.sub_category.length==0">{{item.stt}}</td>
                   <td v-show="item.import_day.length==0">{{item.stt}}</td>
                   <td v-show="item.question_code.length==0">{{item.stt}}</td>
                   <td v-show="item.question_number.length==0">{{item.stt}}</td>
                   <td v-show="item.question_answer.length==0">{{item.stt}}</td>
                   <td v-show="item.question_result.length==0">{{item.stt}}</td>


                   <!-- show column error  -->
                  <td v-show="item.user_gender.length==0">{{"Giới Tính"}}</td>
                  <td v-show="item.user_name.length==0">{{"Họ Tên"}}</td>
                  <!-- <td v-show="item.user_name.length<5||item.user_name.length>30">{{"Họ Tên"}}</td> -->

                  <td v-show="item.user_address.length==0">{{"Địa chỉ"}}</td>
                   <td v-show="item.user_code.length==0">{{"Mã số"}}</td>
                  <td v-show="item.user_phone.length==0">{{"Số điện thoại"}}</td>
                   <td v-show="item.survey_type.length==0">{{"Loại khảo sát"}}</td>
                  <td v-show="item.survey_name.length==0">{{"Tên khảo sát"}}</td>
                   <td v-show="item.survey_code.length==0">{{"Mã khảo sát"}}</td>
                   <td v-show="item.user_yearofbirth.length==0">{{"Năm sinh"}}</td>
                   <td v-show="item.survey_day.length==0">{{"Ngày thực hiện khảo sát"}}</td>
                   <td v-show="item.user_province.length==0">{{"Tỉnh thành"}}</td>
                   <td v-show="item.user_career.length==0">{{"Nghề nghiệp"}}</td>
                   <td v-show="item.user_hoobit.length==0">{{"Sở thích"}}</td>
                   <td v-show="item.story_success.length==0">{{"Câu chuyện thành công"}}</td>
                   <td v-show="item.course_goal.length==0">{{"Mục tiêu khóa học"}}</td>
                   <td v-show="item.course_action.length==0">{{"Kế hoạch hành động"}}</td>
                   <td v-show="item.course_final_rate.length==0">{{"Đánh giá cuối khóa"}}</td>
                   <td v-show="item.user_typeofsick.length==0">{{"Loại bệnh"}}</td>
                   <td v-show="item.year_foundout.length==0">{{"Năm phát hiện"}}</td>
                   <td v-show="item.participation_package.length==0">{{"Gói tham gia"}}</td>
                   <td v-show="item.survey_type_code.length==0">{{"Mã loại khảo sát"}}</td>
                   <td v-show="item.category_code.length==0">{{"Mã category"}}</td>
                   <td v-show="item.category.length==0">{{"Category"}}</td>
                   <td v-show="item.sub_category_code.length==0">{{"Mã Subcategory"}}</td>
                   <td v-show="item.sub_category.length==0">{{"Subcategory"}}</td>
                   <td v-show="item.import_day.length==0">{{"Ngày import"}}</td>
                   <td v-show="item.question_code.length==0">{{"Mã câu hỏi"}}</td>
                   <td v-show="item.question_number.length==0">{{"Câu hỏi"}}</td>
                   <td v-show="item.question_answer.length==0">{{"Câu trả lời"}}</td>
                   <td v-show="item.question_result.length==0">{{"Kết quả"}}</td>
          




                  <!-- show details  -->
                  <td v-show="item.user_gender.length==0" style="color:red">{{ "Thiếu thông tin giới tính" }}</td>
                  <td v-show="item.user_name.length==0" style="color:red">{{  "Thiếu họ tên" }}</td>
                   <!-- <td v-show="item.user_name.length<5||item.user_name.length>30" style="color:red">{{  "Vượt quá ký tự cho phép" }}</td> -->

                  <td v-show="item.user_address.length==0" style="color:red">{{ "Thiếu thông tin địa chỉ" }}</td>
                   <td v-show="item.user_code.length==0" style="color:red">{{" Thiếu Mã số"}}</td>
                   <td  v-show="item.survey_type.length==0" style="color:red">{{" Thiếu Loại khảo sát"}}</td>
                   <td v-show="item.survey_name.length==0" style="color:red">{{" Thiếu Tên khảo sát"}}</td>
                   <td  v-show="item.survey_code.length==0" style="color:red">{{" Thiếu Mã khảo sát"}}</td>
                   <td v-show="item.user_yearofbirth.length==0" style="color:red">{{" Thiếu Năm sinh"}}</td>
                   <td v-show="item.survey_day.length==0" style="color:red">{{"Thiếu Ngày thực hiện khảo sát"}}</td>
                   <td v-show="item.user_province.length==0" style="color:red">{{"Thiếu Tỉnh thành"}}</td>
                   <td v-show="item.user_career.length==0" style="color:red">{{" Thiếu Nghề nghiệp"}}</td>
                   <td v-show="item.user_hoobit.length==0" style="color:red">{{"Thiếu Sở thích"}}</td>
                   <td v-show="item.story_success.length==0" style="color:red">{{" Thiếu Câu chuyện thành công"}}</td>
                   <td v-show="item.course_goal.length==0" style="color:red">{{" Thiếu Mục tiêu khóa học"}}</td>
                   <td v-show="item.course_action.length==0" style="color:red">{{" Thiếu Kế hoạch hành động"}}</td>
                   <td v-show="item.course_final_rate.length==0" style="color:red">{{" Thiếu Đánh giá cuối khóa"}}</td>
                   <td v-show="item.user_typeofsick.length==0" style="color:red">{{"Thiếu Loại bệnh"}}</td>
                   <td v-show="item.year_foundout.length==0" style="color:red">{{"Thiếu Năm phát hiện"}}</td>
                   <td v-show="item.participation_package.length==0" style="color:red">{{"Thiếu Gói tham gia"}}</td>
                   <td v-show="item.survey_type_code.length==0" style="color:red">{{"Thiếu Mã loại khảo sát"}}</td>
                   <td v-show="item.category_code.length==0" style="color:red">{{"Thiếu Mã category"}}</td>
                   <td v-show="item.category.length==0" style="color:red">{{"Thiếu Category"}}</td>
                   <td v-show="item.sub_category_code.length==0" style="color:red">{{"Thiếu Mã Subcategory"}}</td>
                   <td v-show="item.sub_category.length==0" style="color:red">{{"Thiếu Subcategory"}}</td>
                   <td v-show="item.import_day.length==0" style="color:red">{{"Thiếu Ngày import"}}</td>
                   <td v-show="item.question_code.length==0" style="color:red">{{"Thiếu Mã câu hỏi"}}</td>
                   <td v-show="item.question_number.length==0" style="color:red">{{"Thiếu Câu hỏi"}}</td>
                   <td v-show="item.question_answer.length==0" style="color:red">{{"Thiếu Câu trả lời"}}</td>
                   <td v-show="item.question_result.length==0" style="color:red">{{"Thiếu Kết quả"}}</td>
          

               
        
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
                @click="message_success()"
              >
                Tiếp tục
              </b-button>
            </div>
          </div>
        </b-col>
      </b-row>
    </b-container>
        <user-import-modal/>

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
  components: { 'user-import-modal': () => import('./messages/messageContinue.vue') },

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
      
     
      var totalcount = this.staff_list.length;
      
      return totalcount;
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
    message_success()
  {
      
      this.$bvModal.show('user-import-modal');
        
  }

  },
  mounted() {
    // this.loadData();
  },

  
  
};
</script>
