
import { Link } from 'expo-router';
import { StyleSheet, Text, View } from 'react-native';
import { Button } from 'react-native-paper';


export default function Cadastrar() {
  return (
    <View style={styles.container}>
      <Text>Eu Sou ?</Text>
     
      <Link href="/Usuario"><Button icon="account-edit">Cliente</Button></Link>
      <Link href="/Usuario"><Button icon="account-edit">Barbeiro</Button></Link>

    </View>
  );
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
});
