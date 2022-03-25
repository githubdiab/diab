<template>
  <div class="user-import-list-page w-100">
    <b-container fluid class="user-import-list-page__body mb-6 mt-6">
      <b-row>
        <b-col>
          <div class="card card-custom gutter-b">
            <div class="card-body mt-0">
              <p > Tổng số bản ghi: {{ tableLength }}</p>       
               <div>
              </div> 
              <template-table
                id="my-table"
                :column="column"
                :data="staff_list"
                :paging="paging"
                :tableAction="false"
                :selectAction="false"
                :searchAction="false"
                @sortBy="sortRequest"
              >
                <template v-slot:body="{ item , index }">
                    <td style="  text-align: center">{{ index + 1 }}</td>
                  <td style="width: 100px;">{{ item.user_name }}</td>
                  <td>{{ item.user_code }}</td>
                  <td >{{item.survey_type }}</td>
                  <td>{{ item.survey_name }}</td>
                  <td style=" padding-left: 30px;">{{ item.survey_code }}</td>
                  <td style=" padding-left: 20px;">{{ item.user_yearofbirth }}</td>
                  <td>{{ item.user_gender }}</td>
                <td style="  text-align: center">
                    {{ $moment(item.survey_day).format('DD/MM/YYYY') }}
                  </td>
                  <td>{{ item.user_province }}</td>
                  <td>{{ item.user_phone }}</td>
                  <td>{{ item.user_career }}</td>
                
                  <td>{{ item.user_address }}</td>
                  <td>{{ item.user_hoobit }}</td>
                  <td>{{ item.story_success }}</td>
                  <td>{{ item.course_goal }}</td>
                  <td>{{ item.course_action }}</td>
                  <td>{{ item.course_final_rate }}</td>
                  <td style=" padding-left: 30px;">{{ item.user_typeofsick }}</td>
                  <td style=" padding-left: 30px;">{{ item.year_foundout }}</td>
                  <td>{{ item.participation_package }}</td>
                  <td>{{ item.survey_type_code }}</td>
                  <td>{{ item.category_code }}</td>
                  <td>{{ item.category }}</td>
                  <td style=" padding-left: 30px;">{{ item.sub_category_code }}</td>
                  <td>{{ item.sub_category }}</td>
                  <td>
                    {{ $moment(item.import_day).format('DD/MM/YYYY') }}
                  </td>
                  <td>{{ item.question_code }}</td>
                  <td>{{ item.question_number }}</td>
                  <td>{{ item.question_answer }}</td>
                  <td style=" padding-left: 30px;">{{ item.question_result }}</td>
                </template>
              </template-table>

               <!-- <b-pagination
             
              :total-rows="this.staff_list.length"
             v-model="paging.currentPage"
            :per-page="paging.perpage"
               @input="handlePageChange"
           
            aria-controls="my-table"

                ></b-pagination> -->
                <br>
                <br>
              <b-button
                class="btn btn-success ml-2"
                type="button"
                style="float: right"
               :disabled="isSelectFile"
                @click="$router.go(-1)"
              >
                Hủy
              </b-button>
              <b-button
                class="btn btn-success ml-2"
                type="button"
                style="float: right"
                :disabled="isSelectFile"
                @click="NoError()"
              
              >           
                Validate
              </b-button>

              <!-- <b-button
                class="btn btn-success ml-2"

                type="button"
                style="float: right"
                @click="NoError()"
              
              >           
                Message
              </b-button> -->
             

            </div>
          </div>
        </b-col>
      </b-row>

     

    
    </b-container>
    <user-import-modal v-bind:staff_list="staff_list"/>

    <user-import-modal2 v-bind:staff_list="staff_list"/>

     <user-import-modal_checkrecord v-bind:staff_list="staff_list"/>

    
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
  text-align: left;
  width: 60px;
  font-size: 13px;
  line-height: 20px;
   font-style: normal;
   font-family: 'Nunito';
}

table {
  width: 100%;
  table-layout: fixed;
}
div {
  white-space: nowrap;
  word-wrap: normal;
  text-align: left;
}
p {
  text-align: left;
}

// data {
//   white-space: nowrap;
// }
</style>

<script>
export default {
components: { 'user-import-modal': () => import('./components/messages/messageNoError.vue'), 

               'user-import-modal2': () => import('./components/messages/messageSuccess.vue') ,
               
               'user-import-modal_checkrecord': () => import('./components/messages/messageCheckRecord.vue') 
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
        total: 0,
        
        
      //  total: 0,
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
          label: 'Số thứ tự',
          sortable: false,
        },
        {
          key: 'user_name',
          label: 'Bệnh nhân',
          sortable: false,
        },
        {
          key: 'user_code',
          label: 'Mã số',
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
        {
          key: 'survey_code',
          label: 'Mã khảo sát',
          sortable: false,
        },
        {
          key: 'user_yearofbirth',
          label: 'Năm sinh',
          sortable: false,
        },
        {
          key: 'user_gender',
          label: 'Giới Tính',
          sortable: false,
        },
        {
          key: 'survey_day',
          label: 'Ngày thực hiện khảo sát',
          sortable: false,
        },
        {
          key: 'user_province',
          label: 'Tỉnh thành',
          sortable: false,
        },
        {
          key: 'user_phone',
          label: 'Số điện thoại',
          sortable: false,
        },
        {
          key: 'user_career',
          label: 'Nghề nghiệp',
          sortable: false,
        },
       
        {
          key: 'user_address',
          label: 'Địa chỉ',
          sortable: false,
        },
        {
          key: 'user_hoobit',
          label: 'Sở thích',
          sortable: false,
        },

        {
          key: 'story_success',
          label: 'Câu chuyện',
          sortable: false,
        },
        {
          key: 'course_goal',
          label: 'Mục tiêu khóa học',
          sortable: false,
        },
        {
          key: 'course_action',
          label: 'Kế hoạch hành động',
          sortable: false,
        },

        {
          key: 'course_final_rate',
          label: 'Đánh giá cuối khóa',
          sortable: false,
        },
        {
          key: 'user_typeofsick',
          label: 'Loại bệnh',
          sortable: false,
        },
        {
          key: 'year_foundout',
          label: 'Năm phát hiện',
          sortable: false,
        },
        {
          key: 'participation_package',
          label: 'Gói tham gia',
          sortable: false,
        },
        {
          key: 'survey_type_code',
          label: 'Mã loại khảo sát',
          sortable: false,
        },

        {
          key: 'category_code',
          label: 'Mã category',
          sortable: false,
        },
        {
          key: 'category',
          label: 'Category',
          sortable: false,
        },
        {
          key: 'sub_category_code',
          label: 'Mã Subcategory',
          sortable: false,
        },
        {
          key: 'sub_category',
          label: 'Subcategory',
          sortable: false,
        },
        {
          key: 'import_day',
          label: 'Ngày import',
          sortable: false,
        },

        {
          key: 'question_code',
          label: 'Mã câu hỏi',
          sortable: false,
        },
        {
          key: 'question_number',
          label: 'Câu hỏi',
          sortable: false,
        },
        {
          key: 'question_answer',
          label: 'Câu trả lời',
          sortable: false,
        },
        {
          key: 'question_result',
          label: 'Kết quả',
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
   

    tableLength: function () {
    //  return this.staff_list.filter((item) => item.participation_package )
      let totalcount = this.staff_list.length;
    //  var totalcount = this.column[2].key
      return totalcount;
    },

      elimited: function()
   {   
    return this.staff_list.filter((item, pos, self) => self.findIndex(v => v.user_code === item.user_code) === pos);
  },
  },
  created() {
    this.$root.$refs.A = this
  },
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
   
    handleClick() {   
     
      this.$router.push({
        name: 'validate',
        params: {
          
            staff_list : this.staff_list           
        },
      });   
          // <message/>
     
        // this.$bvModal.show('user-import-modal');
      
    

    },
    // async handleImportUser() {
    //   this.$nextTick(() => {
    //     this.$bvModal.show('user-import-modal');
    //   });
    // },
     handlePageChange(value) {
      this.paging.page = value;
    },
    async NoError() {
       var mess_error='';
      
        for(let i=0;i<Number(this.staff_list.length);i++)
       {
         if(this.staff_list[i].user_name =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].user_code ==''||this.staff_list[i].user_code.length>10)
         {        
          mess_error='error'
         }
          if(this.staff_list[i].survey_type =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].survey_code =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].survey_name =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].user_yearofbirth =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].user_gender ==''||this.staff_list[i].user_gender!='Nam'&&this.staff_list[i].user_gender!='Nữ')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].user_phone ==''||this.staff_list[i].user_phone.length!=10)
         {        
          mess_error='error'
         }
          if(this.staff_list[i].survey_day ==''||this.staff_list[i].survey_day=='Invalid date')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].user_province =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].stt =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].user_career =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].user_hoobit =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].user_address =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].story_success ==''|| this.staff_list[i].story_success.length>1000)
         {        
          mess_error='error'
         }
          if(this.staff_list[i].course_goal =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].course_action =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].course_final_rate =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].user_typeofsick =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].year_foundout =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].participation_package =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].survey_type_code =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].category_code =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].category =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].sub_category_code =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].sub_category =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].import_day ==''||this.staff_list[i].import_day=='Invalid date')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].question_code =='')
         {        
          mess_error='error'
         }
          if(this.staff_list[i].question_number =='')
         {        
          mess_error='error'
         }
           if(this.staff_list[i].question_answer =='')
         {        
          mess_error='error'
         }
           if(this.staff_list[i].question_result =='')
         {        
          mess_error='error'
         }

        
        
       }
        if(mess_error=='error')
        {
           this.$router.push({
        name: 'validate',
         method:{
            
          },
        params: {
          
            staff_list : this.staff_list         
        },
          });   
         
        }
       else
       {
          
           this.$bvModal.show('user-import-modal');
        
       }

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
  },
 
     
 
};
</script>
