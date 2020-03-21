## This Python 3 environment comes with many helpful analytics libraries installed
# It is defined by the kaggle/python docker image: https://github.com/kaggle/docker-python
# For example, here's several helpful packages to load in 

import numpy as np # linear algebra
import pandas as pd # data processing, CSV file I/O (e.g. pd.read_csv)

# Input data files are available in the "../input/" directory.
# For example, running this (by clicking run or pressing Shift+Enter) will list the files in the input directory
import matplotlib.pyplot as plt
import seaborn as sns
%matplotlib inline


df1 = pd.read_csv('C:/Users/Lenovo/Downloads/Autism_Data (3).arff')
df2 = pd.read_csv('C:/Users/Lenovo/Downloads/autism-screening-for-toddlers/Toddler Autism dataset July 2018.csv')

# Any results you write to the current directory are saved as output.


df1.head() #data of autism in kids
df2.head() #data of autism in adults


#To know how many Toddlers and adults are affected in general
sns.set_style('whitegrid')
data1= df1[df1['Class/ASD']=='YES']
data2= df2[df2['Class/ASD Traits ']=='Yes']
print("Adults: ",len(data1)/len(df1) * 100)
print("Toddlers:",len(data2)/len(df2) * 100)



#Let's visualize the jaundice born child based on gender
fig, ax = plt.subplots(1,2,figsize=(20,6))
sns.countplot(x='jundice',data=data1,hue='gender',ax=ax[0])
ax[0].set_title('ASD positive Adults born with jaundice based on gender')
ax[0].set_xlabel('Jaundice while birth')
sns.countplot(x='Jaundice',data=data2,hue='Sex',ax=ax[1])
ax[1].set_title('ASD positive Toddlers born with jaundice based on gender')
ax[1].set_xlabel('Jaundice while birth')

#Let's see the sex distribution of ASD positive
sns.countplot(x = 'Qchat-10-Score', hue = 'Sex', data = asd)


#Let's see the age distribution of ASD positive
fig, ax = plt.subplots(1,2,figsize=(20,6))
sns.distplot(data1['age'],kde=False,bins=45,color='darked',ax=ax[0])
ax[0].set_xlabel('Adult age in years')
ax[0].set_title('Age distribution of ASD positive')
sns.Distplot(data2['Age_Mons'],kde=False,bins=30,color='darkred',ax=ax[1])
ax[1].set_xlabel('Toddlers age in months')
ax[1].set_title('Age distribution of ASD positive')
