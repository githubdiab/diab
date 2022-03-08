<template>
  <div class="user-import-list-page w-100">
    <basic-subheader>
      <template v-slot:actions>
       
         
        <b-button
          type="button"
          id="show-btn"
          @click="returnPage()">
          <span class="svg-icon">
            <inline-svg src="/media/svg/icons/Neolex/Arrows/arrow-left.svg" />
          </span>
          Trở về trước
        </b-button>
      </template>
    </basic-subheader>
     <b-container fluid class="user-import-list-page__body mb-6 mt-6">
      <b-row>
        <b-col>
          <div class="card card-custom gutter-b">
            <div class="card-body mt-0">
                <p style="font-size:13px"><b>{{user_details[0].user_name}}  </b></p>      
             
                 
             
              <table v-bind:user_details="user_details">
                <tr>
                  <th>
                    Năm sinh         
                  </th>
                   <th>
                    Số điện thoại         
                  </th>
                  <th>
                    Sở thích         
                  </th>
                  <th>
                    Câu chuyện          
                  </th>
                </tr>
                <td> {{user_details[0].user_yearofbirth}} </td>
                <td> {{user_details[0].user_phone}} </td>
                <td> {{user_details[0].user_hoobit}} </td>
                <td> {{user_details[0].story_success}} </td>
              </table>
               <br>
               <br>
                <table v-bind:user_details="user_details">
                <tr id="row1">
                  <th>
                    Nghề nghiệp         
                  </th>
                   <th>
                    Tỉnh thành         
                  </th>
                  <th>
                    Địa chỉ         
                  </th>
                  <th>
                   Kế hoạch hành động         
                  </th>
                </tr>
                <td> {{user_details[0].user_career}} </td>
                <td> {{user_details[0].user_province}} </td>
                <td style="white-space: initial;"> {{user_details[0].user_address}} </td>
                <td> {{user_details[0].course_action}} </td>
              </table>
               <br>
              <p  style="font-size:16px"><b> Kết quả khảo sát </b></p>       
              
              <template-table
                :id="table"
                :column="column"
                :data="staff_list"
                :paging="paging"
                :tableAction="false"
                :selectAction="false"
                :searchAction="false"
                 @search="searchRequest"         
              >
                <template v-slot:body="{ item , index  }">
                <td  style="text-align: left"> {{ index+1}} </td>
                  <td  style="text-align: left"> {{ item.category }} </td>
                 
             
                   <td  style="text-align: left">{{ item.question_number }}</td>
                  <td  style="text-align: left">{{ item.question_answer }}</td>
               
                </template>
              </template-table>
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
   font-family: 'Nunito';
   font-size: 13px;
  font-weight: bold;
 // color: black;
  line-height: 25px;
  text-align: left;

   
//  
 //word-wrap: break-word;
  overflow: hidden;
  text-overflow: ellipsis;
  //text-align: center;
  width: 50px;
}
.information{
text-decoration: gray;

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
 width: 36px;
//text-align: left;

  
}

#showbtn{
 float: right;
 
}
table {
    border-collapse: collapse;
   
    margin: 15px;
}

th{
   color:gray;
   font-style: normal;
   font-family: 'Nunito';
   font-size: 13px;
    line-height: 25px;
 text-align: left;
}
body{
 //color:gray
}
td{
 

}

 
// data {
//   white-space: nowrap;
// }
</style>

<script>
import axios from'axios'
export default {
 props:{
    user_code: {
      type: Number,
      default: null,
    },
    id:{
      type:String,
      default:null,
    }
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
          label: 'Số thứ tự',
          sortable: false,
        },
        {
          key: 'category',
          label: 'Nhóm câu hỏi',
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

        
       
      ],
      
      staff_list: [],
      user_details: [],
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
     
      let totalcount = this.staff_list.length ;
    //  var totalcount = this.column[2].key
      return totalcount;
    },
  },
  created() {},
  watch: {
  paging: {
     // loadData_surveydetails() // data search
  }
  
  },
  methods: {
     loadData_surveydetails() {
     
      axios.get('https://localhost:44380/api/surveyimportdetails/survey_id', {
          params: { user_id : this.id},
        })
        .then(({ data }) => {
          this.selected = [];
         this.data = data.items || [];
          this.paging.total = data.total;
          this.staff_list = data
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
     loadData_details() {
     
      axios.get('https://localhost:44380/api/surveyimportresults/details',{
         params: { user_code:this.user_code },
         
        })
        .then(({ data }) => {
       //   this.selected = [];
      //   this.data = data.items || [];
      //    this.paging.total = data.total;
          this.user_details = data
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
      returnPage() {
      this.$router.push({
        name: 'user_import_list',
      });
    },
   
  
    
    
    // async handleImportUser() {
    //   this.$nextTick(() => {
    //     this.$bvModal.show('user-import-modal');
    //   });
    // },

   

 
    },
  
    
  
  
mounted()
{
  this.loadData_surveydetails();
  this.loadData_details();
}
 
};
</script>
