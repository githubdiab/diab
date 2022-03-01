<template>
         
  <b-modal
    id="user-import-modal2"
    ref="user-import-modal2"
    hide-header
    
    
  >
            <div style="text-align:center; ">
            <span class="svg-tick" >
            <inline-svg src="/media/svg/import/sss.svg" style="justify-self: center;"/>
             </span>
            </div>
           
          <div style="text-align:center;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 14px;;">
          
            Tổng số khách hàng import thành công: {{this.staff_list.length}}
         
         
          </div>

          <div style="text-align:center;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 14px;;">
          
             Tổng số bản ghi import thành công: {{this.account_list.length}} 
         
          </div>
    <template #modal-footer style="text-align:center">
        <!--<b-button class="btn btn-secondary" href="#" tabindex="0">
          <span class="svg-icon">
            <inline-svg src="/media/svg/icons/Neolex/Basic/power.svg" />
          </span>
          Hủy
        </b-button> -->

        <b-button
          class="btn btn-success ml-2"
          href="#"
          @click="handleClick()"
          tabindex="0"
        >
        
        Tiếp tục
          
        </b-button>

        
      
      
    </template>
  </b-modal>
 
</template>

<script>
import axios from 'axios'

export default {
  name: 'Modal',
  props:{
    staff_list: {
      type: Array,
      default: () => [],
  },
  
  },
  computed: {},
  watch: {},
  // mounted() {this.$root.$on('Modal',()=>{
  //   this.handleClick()
  // })},
  
  data() {
    return {
      isMounted: false,
      loading: false,
      isSelectFile: false,
      form: {},
      validationState: {},
      error: {},
      account_list:[],
    };
  },
  created() {
     
      
    },
    
  mounted(){
   
   this.loadData_account();        
    

    
    
      
  },

  methods: {
   
    handleClick() {
     
      this.AddSurvey();
       this.$router.push({
        name: 'user_import_list',
         method:{
          // staff_list : data
          },
        params: {
          
         staff_list : this.staff_list
        },
          })
  
    },
  async AddSurvey ()
 {
 //  this.addUser();
    
    const data = await axios.get('https://localhost:44380/api/accountimport/id',{
       params:{
   
       }
     })
    .then(res => res.data);
   // const n = data.length 
        for(let j=0;j<=Number(this.staff_list.length);j++)
     {
   await  axios.post('https://localhost:44380/api/surveyimport', null, {
      params: {
        
        
      user_id : data[j].id,
     // user_id: '1a9d3f69-40b2-4206-b59e-dc4ea6c3a18c',
      course_goal: this.staff_list[j].course_goal,
      course_action:this.staff_list[j].course_action,
      course_final_rate:this.staff_list[j].course_final_rate,
      participation_package:this.staff_list[j].participation_package,
      survey_type_code:this.staff_list[j].survey_type_code,
      survey_type:this.staff_list[j].survey_type,
      survey_code:this.staff_list[j].survey_code,
      survey_name:this.staff_list[j].survey_name,
      survey_day:this.staff_list[j].survey_day,
      import_day:this.staff_list[j].import_day,
           
        },
      });
     
   //   await axios.get('https://localhost:44380/api/surveyimport')
   this.AddSurveyDetails();
     }
    
 },
  async AddSurveyDetails ()
 {
  // this.addUser();
 //  this.AddSurvey();
     for(let k=0;k<=Number(this.staff_list.length);k++)
     {
    const data = await axios.get('https://localhost:44380/api/surveyimport/id',{
       params:{
   //     user_code:this.staff_list[i].user_code,
   
       }
     })
    .then(res => res.data);

    
   await  axios.post('https://localhost:44380/api/surveyimportdetails', null, {
      params: {
       survey_id : data[k].id,
     // user_id: '1a9d3f69-40b2-4206-b59e-dc4ea6c3a18c',
       category_code : this.staff_list[k].category_code,
       category: this.staff_list[k].category,
       sub_category_code: this.staff_list[k].sub_category_code,
       sub_category:this.staff_list[k].sub_category,
       question_code:this.staff_list[k].question_code,
       question_number:this.staff_list[k].question_number,
       question_answer:this.staff_list[k].question_answer,
       question_result:this.staff_list[k].question_result,
           
        },
      });
     
  
     }
 },
    goback() {
      this.$bvModal.hide('user-import-modal2');
    },
    goOn() {
      
    },

     loadData_account() {
     
      axios.get('https://localhost:44380/api/surveyimportdetails', {
          params: { ...this.searchParams },
        })
        .then(({ data }) => {
          this.selected = [];
          this.data = data.items || [];
          this.paging.total = data.total;
          this.account_list = data
        })
        
      return;
    },
  },
 
};
</script>

<style lang="scss">
#glucose-modal {
  .modal-dialog {
    // width: 370px;
    // height: 582px;
   
  }
}
.modal-footer{
  justify-content: center;
  //text-align: center;
}
.svg-tick{
    justify-content: center;
}


</style>
