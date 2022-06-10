<template>
  <div class="user-import-list-page w-100">
    <b-container fluid class="user-import-list-page__body mb-6 mt-6">
      <b-row>
        <b-col>
          <div class="card card-custom gutter-b">
            <div class="card-body mt-0">
              <div id="container">
                <div class="inline">
                  <p  v-show="column">
                  <span class="svg-icon">
                  <inline-svg src="/media/svg/import/group.svg" />
                  </span>
                    Tổng số bản ghi bị lỗi : {{ NullLength }}
                  </p>
                </div>
                <div class="inline">
                  <p  v-show="column">
                    <span class="svg-icon">
                  <inline-svg src="/media/svg/import/group.svg" />
                  </span>
                    Tổng số khách hàng bị ảnh hưởng : {{ count_NewUser }}
                  </p>
                </div>
              </div>
              <template-table
                id="my-table"
                :class="table"
                :column="column"
                :data="NullItems"
                :paging="paging"
                :tableAction="false"
                :selectAction="false"
                :searchAction="false"
              
              
              >
                <template v-slot:body="{ item ,index}">
          
             <!-- show stt   -->
               <td>{{index+1}}  </td>  
             <!-- show name   -->              
               <td>{{ item.user_name }}</td>       
              <!-- show code   -->
                 <td style=" text-align: left; padding-left: 45px;">{{ item.user_code }}</td>  
              <!-- show row error  -->     
              <td style=" text-align: left ; padding-left: 45px;">{{+item.stt}} </td>  
            
                  
                  
                 

                   <!-- show column error  -->
              <td>
                   <p    v-show="item.user_gender.length==0">{{"user_gender"}}</p>  
                   <p    v-show="item.user_name.length==0">{{"user_name"}}</p>  
                   <p    v-show="item.user_address.length==0">{{"user_address"}}</p>  
                   <p    v-show="item.user_code.length==0">{{"user_code"}}</p>  
                   <p    v-show="item.user_phone.length==0">{{"user_phone"}}</p>  
                   <p    v-show="item.survey_type.length==0">{{"survey_type"}}</p>  
                   <p    v-show="item.survey_name.length==0">{{"survey_name"}}</p>  
                   <p    v-show="item.survey_code.length==0">{{"survey_code"}}</p>  
                   <p    v-show="item.user_yearofbirth.length==0">{{"user_yearofbirth"}}</p>  
                   <p    v-show="item.survey_day.length==0">{{"survey_day"}}</p>  
                   <!-- <p    v-show="item.user_province.length==0">{{"user_province"}}</p>  
                   <p    v-show="item.user_career.length==0">{{"user_career"}}</p>  
                   <p    v-show="item.user_hoobit.length==0">{{"user_hoobit"}}</p>   -->
                   <!-- <p    v-show="item.story_success.length==0">{{"story_success"}}</p>   -->
                   <!-- <p    v-show="item.course_goal.length==0">{{"course_goal"}}</p>   -->
                   <!-- <p    v-show="item.course_action.length==0">{{"course_action"}}</p>   -->
                  <!-- <p    v-show="item.course_final_rate.length==0">{{"course_final_rate"}}</p>   -->
                   <p    v-show="item.user_typeofsick.length==0">{{"user_typeofsick"}}</p>  
                   <p    v-show="item.year_foundout.length==0">{{"year_foundout"}}</p>  
                   <p    v-show="item.participation_package.length==0">{{"participation_package"}}</p>  
                   <!-- <p    v-show="item.survey_type_code.length==0">{{"survey_type_code"}}</p>   -->
                   <p    v-show="item.category_code.length==0">{{"category_code"}}</p>  
                   <p    v-show="item.category.length==0">{{"category"}}</p>  
                   <p    v-show="item.sub_category_code.length==0">{{"sub_category_code"}}</p>  
                   <p    v-show="item.sub_category.length==0">{{"sub_category"}}</p>  
                   <!-- <p    v-show="item.import_day.length==0">{{"import_day"}}</p>   -->
                   <p    v-show="item.question_code.length==0">{{"question_code"}}</p>  
                   <p    v-show="item.question_number.length==0">{{"question_number"}}</p>  
                   <p    v-show="item.question_answer.length==0">{{"question_answer"}}</p>  
                   <!-- <p    v-show="item.question_result.length==0">{{"question_result"}}</p>   -->
              </td>
             


                  <!-- show details  -->
                 
                 <td>
                    <p    v-show="item.user_gender.length==0" style="color:red">{{ "Thiếu thông tin bắt buộc: Giới tính"}}</p> 
                    <p    v-show="item.user_phone.length==0" style="color:red">{{ "Thiếu thông tin bắt buộc: Số điện thoại"}}</p> 
                    <p    v-show="item.user_name.length==0" style="color:red">{{  "Thiếu thông tin bắt buộc: Họ tên"}}</p>           
                    <p    v-show="item.user_address.length==0" style="color:red">{{ "Thiếu thông tin bắt buộc: địa chỉ"}}</p>                   
                    <p    v-show="item.user_code.length==0" style="color:red">{{" Thiếu thông tin bắt buộc: Mã số"}}</p>                    
                    <p    v-show="item.survey_type.length==0" style="color:red">{{" Thiếu Loại khảo sát"}}</p>                      
                    <p    v-show="item.survey_name.length==0" style="color:red">{{" Thiếu Tên khảo sát"}}</p>                      
                    <p    v-show="item.survey_code.length==0" style="color:red">{{" Thiếu Mã khảo sát"}}</p>   
                    <p    v-show="item.user_yearofbirth.length==0" style="color:red">{{" Thiếu thông tin bắt buộc: Năm sinh"}}</p>     
                    <p    v-show="item.survey_day.length==0" style="color:red">{{"Thiếu Ngày thực hiện khảo sát"}}</p>  
                    <!-- <p    v-show="item.user_province.length==0" style="color:red">{{"Thiếu Tỉnh thành"}}</p>  
                    <p    v-show="item.user_career.length==0" style="color:red">{{" Thiếu Nghề nghiệp"}}</p>  
                    <p    v-show="item.user_hoobit.length==0" style="color:red">{{"Thiếu Sở thích"}}</p>   -->
                    <!-- <p    v-show="item.story_success.length==0" style="color:red">{{" Thiếu Câu chuyện người dùng"}}</p>  
                    <p    v-show="item.course_goal.length==0" style="color:red">{{" Thiếu Mục tiêu khóa học"}}</p>  
                    <p    v-show="item.course_action.length==0" style="color:red">{{" Thiếu Kế hoạch hành động"}}</p>   -->
                    <!-- <p    v-show="item.course_final_rate.length==0" style="color:red">{{" Thiếu Đánh giá cuối khóa"}}</p>   -->
                    <p    v-show="item.user_typeofsick.length==0" style="color:red">{{"Thiếu Loại bệnh"}}</p>  
                    <p    v-show="item.year_foundout.length==0" style="color:red">{{"Thiếu thông tin bắt buộc: Năm phát hiện"}}</p>  
                    <p    v-show="item.participation_package.length==0" style="color:red">{{"Thiếu Gói tham gia"}}</p>  
                    <!-- <p    v-show="item.survey_type_code.length==0" style="color:red">{{"Thiếu Mã loại khảo sát"}} </p>   -->
                    <p    v-show="item.category_code.length==0" style="color:red">{{"Thiếu Mã category"}}</p>  
                    <p    v-show="item.category.length==0" style="color:red">{{"Thiếu Category"}}</p>  
                    <p    v-show="item.sub_category_code.length==0" style="color:red">{{"Thiếu Mã Subcategory"}}</p>  
                    <p    v-show="item.sub_category.length==0" style="color:red">{{"Thiếu Subcategory"}}</p>  
                    <!-- <p    v-show="item.import_day.length==0" style="color:red">{{"Thiếu Ngày import"}}</p>   -->
                    <p    v-show="item.question_code.length==0" style="color:red">{{"Thiếu Mã câu hỏi"}}</p>   
                    <p    v-show="item.question_number.length==0" style="color:red">{{"Thiếu Câu hỏi"}}</p>   
                    <p    v-show="item.question_answer.length==0" style="color:red">{{"Thiếu Câu trả lời"}}</p>  
                    <!-- <p    v-show="item.question_result.length==0" style="color:red">{{"Thiếu thông tin bắt buộc: Kết quả"}}</p>    -->
                 </td>
              
                </template>
              </template-table>
             <br>
          <div style="float: right">
            
               <br>
               <br>
                   <b-button
                class="btn btn-success ml-2"
                id="Button"
                type="button"
                :disabled="isSelectFile"
                @click="message_success()"
              >
                Tiếp tục
              </b-button>

              <b-button
                class="btn btn-success ml-2"
                id="Button"
                type="button"
                 :disabled="isSelectFile"
                @click="$router.go(-2)"
              >
                Hủy
              </b-button>

          
          </div>
            </div>
          </div>
        </b-col>
      </b-row>
    </b-container>
        <user-import-modal v-bind:staff_list="elimited" />
        <user-import-modal2  v-bind:staff_list="elimited" />
       <user-import-modal_checkrecord v-bind:staff_list="elimited"/>
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

div {
 white-space: nowrap;
 word-wrap: normal;
  text-align: left;

}
p {
  white-space: nowrap;
  word-wrap: normal;
  text-align: left;
  align-content: center;
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


td{
 

}
.table {
 // width:500px;
   // table-layout:fixed;
}

.details{
  float: right;
}

// data {
//   white-space: nowrap;
// }
</style>

<script>

export default {
  components: { 'user-import-modal': () => import('./messages/messageContinue.vue'),
  
            'user-import-modal2': () => import('./messages/messageSuccess.vue')  ,

            'user-import-modal_checkrecord': () => import('./messages/messageCheckRecord.vue') 
            },

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
        total: 10,
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
      isSelectFile: false,
    
      
       
      }
     
    
  },
  computed: {
    searchParams() {
      return {
        searchKey: this.filter.searchKey,
        page: this.paging.page,
        size: this.paging.pageSize,
      };
    },
     rows() {
        return this.staff_list.length
      },
    tableLength: function () {
      
     
      var totalcount = this.staff_list.length;
      
      return totalcount;
    },
    
    // NullItems: function() {
    //   return this.staff_list.filter(function(item) {
    //     if(item.user_name == '' || item.user_code=='' ||item.user_gender=='' || item.user_address==''||item.survey_type==''||item.survey_name==''
    //     ||item.survey_code==''||item.user_yearofbirth==''||item.survey_day=='Invalid date'||item.user_yearofbirth==''||item.user_province==''
    //     ||item.user_career==''||item.user_hoobit==''||item.story_success==''||item.course_goal==''||item.course_action==''||item.course_final_rate==''
    //     ||item.user_typeofsick==''||item.year_foundout==''||item.participation_package==''||item.survey_type_code==''||item.category_code==''
    //     ||item.category==''||item.sub_category_code==''||item.sub_category==''||item.import_day=='Invalid date'||item.question_code==''
    //     ||item.question_number==''||item.question_answer==''||item.question_result=='')
    //     return item;
    //   });
    // },
    NullItems: function() {
      return this.staff_list.filter(function(item) {
        if(item.user_name == '' || item.user_code=='' ||item.user_gender=='' || item.user_address==''||item.survey_type==''||item.survey_name==''
        ||item.survey_code==''||item.user_yearofbirth==''||item.survey_day=='Invalid date'||item.user_yearofbirth==''    
        ||item.user_typeofsick==''||item.year_foundout==''||item.participation_package==''||item.category_code==''
        ||item.category==''||item.sub_category_code==''||item.sub_category==''||item.question_code==''
        ||item.question_number==''||item.question_answer=='')
        return item;
      });
    },
     NotNullItems: function() {
      
      return this.staff_list.filter(function(item) {
         if(( item.user_name !=''&& item.user_code!=''&&item.user_gender!=''&& item.user_address!=''&&item.survey_type!=''&&item.survey_name!=
        ''&&item.survey_code!=''&&item.user_yearofbirth!=''&&item.survey_day!='Invalid date'&&item.user_yearofbirth!=
        ''&&item.user_typeofsick!=''&&item.year_foundout!=''&&item.participation_package!=''&&item.category_code!=
        ''&&item.category!=''&&item.sub_category!=''&&item.question_code!=
        ''&&item.question_number!=''&&item.question_answer!=''))
      return item;
      });
    },
    elimited: function()
   {  
    //  console.log(this.NullItems,"not null:"+this.NotNullItems)
 //console.log(this.NotNullItems.filter(item => this.NullItems.every(item2 =>item2.user_code!= item.user_code)));

   return this.NotNullItems.filter(item => this.NullItems.every(item2 => item2.user_code!= item.user_code));
  },
    
   

  NullLength: function () {
    
     
      var totalcount2 = this.NullItems.length;
      
      return totalcount2;
    },

       
   count_NewUser: function()
   {  
     const uniqueValues = new Set(this.NullItems.map(v => v.user_code));
     let result =0;
   if (uniqueValues.size < this.staff_list.length) {
   result =uniqueValues.size
    }
    else
  {
result =uniqueValues.size;
  }
     return result
   }

    
   
  },
    created() {this.$root.$refs.B = this},
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
        
  },

   clickshow_checkrecord: function ()
  {
  
    this.$bvModal.show('user-import-modal_checkrecord');
    this.$bvModal.hide('user-import-modal2');
  } ,

 clickhide: function ()
  {
    this.$bvModal.hide('user-import-modal2');
  } ,

   clickshow: function ()
  {
    this.$bvModal.show('user-import-modal2');
  } ,

  SelectFile()
  {
     this.isSelectFile=true;
  } ,

   NotselectFile()
  {
     this.isSelectFile=false;
  } 

  }
  }
</script>
